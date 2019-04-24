using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Common;
using HEB.NetGiphyA.Util;
using HEB.NetGiphyA.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using ObjDb = HEB.NetGiphyA.Data.Objects;
using ObjView = HEB.NetGiphyA.Models;

namespace HEB.NetGiphyA.Controllers
{
    [Authorize]
    public class PictureController : UserInfoController
    {
        private IPictureService _pictureService;
        private ICategoryService _categoryService;

        public PictureController(IPictureService pictureService,
            ICategoryService categoryService) : base()
        {
            _pictureService = pictureService;
            _categoryService = categoryService;
        }

        /// <summary>
        /// Display all the Giphy files saved in the database for the user
        /// </summary>
        /// <returns> Animated Gif collection</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var model = new MyGifsViewModel();            
            try
            {
                // First we obtain all the Categories the user have in its profile
                var categories = _categoryService.GetCategoriesByUser(GetUserEmail());
                if (categories != null)
                {
                    PictureViewModel viewPictures = null;
                    foreach (var item in categories)
                    {
                        // Get the pics for every Category
                        var dbPictures = _pictureService.GetAllGifsByUserAndCategory(GetUserEmail(), item.CategoryId);
                        if (dbPictures != null)
                        {
                            viewPictures = new PictureViewModel();
                            foreach (var item2 in dbPictures)
                            {
                                viewPictures.Pictures.Add(ObjectTransformations.TransformDbtoViewObj(item2));
                            }
                        }
                        // Add the Category --> Pics into the Category to the model
                        model.ListOfCategorizedPictures.Add(
                            new CategoryPicturesViewModel(ObjectTransformations.TransformDbtoViewObj(item), viewPictures));
                    }
                }
            }
            catch (System.Exception)
            {
                ViewBag.IsError = true;
                ViewBag.Message = $"Unexpected error ocurred while Retrieving the Pictures for each Category for user: '{GetUserEmail()}'. Try again later!";
                return View(model);
            }
            return View(model);
        }

        /// <summary>
        /// Controller method that gets together all the data from the picture which will be saved in the database
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <param name="fileName"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SavePicture(string sourceUrl, string fileName, int height, int width)
        {
            try
            {
                var picture = new ObjView.Picture
                {
                    SourceUrl = sourceUrl,
                    FileName = fileName,
                    Height = height,
                    Width = width
                };
                // Get all the categories previously saved by the user
                var categories = _categoryService.GetCategoriesByUser(GetUserEmail());
                var viewCategories = new List<ObjView.Category>();

                if (categories != null)
                {
                    // Convert DB object to View object
                    foreach (var item in categories)
                    {
                        viewCategories.Add(ObjectTransformations.TransformDbtoViewObj(item));
                    }
                }
                var model = new PictureCategoryViewModel(picture, viewCategories);
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToAction("Index", "SearchGifsController");
            }
        }


        /// <summary>
        /// Download the picture from the Giphy Website to save it in the database for the user
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <returns></returns>
        private byte[] downloadFileFromUrl(string sourceUrl)
        {
            try
            {
                // Read the file from the web and save it eventually in the db
                byte[] downloadedData;
                // Download the picture from the Giphy Website
                WebRequest req = WebRequest.Create(sourceUrl);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();

                //Download in chuncks
                // 8k buffer is very optimal
                byte[] buffer = new byte[8192];
                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                int bytesRead;
                while (true)
                {
                    //Try to read the data
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        //Finished downloading
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);
                    }
                }
                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();
                //Clean up
                stream.Close();
                memStream.Close();
                return downloadedData;
            }
            catch (System.Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Controller which will save the physical picture file into the database
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Save(ObjView.Picture picture)
        {
            try
            {
                if (picture != null)
                {
                    var downloadedData = downloadFileFromUrl(picture.SourceUrl);
                    if (downloadedData != null)
                    {
                        if (picture.CategoryId < 1)
                        {
                            // Add the "GENERAL category to every user only the first time (when there's no category available)
                            picture.CategoryId = _categoryService.AddEditCategory(new ObjDb.Category
                            {
                                CategoryId = picture.CategoryId,
                                Name = Constants.DEFAULT_PIC_CATEGORY,
                                Description = Constants.DEFAULT_PIC_CATEGORY,
                                UserEmail = GetUserEmail()
                            });
                        }
                        // Create the DB Picture object
                        var newDbPic = new ObjDb.Picture
                        {
                            UserEmail = GetUserEmail(),
                            CategoryId = picture.CategoryId,
                            Name = picture.Name,
                            Description = picture.Description,
                            FileName = picture.FileName,
                            SourceUrl = picture.SourceUrl,
                            Height = picture.Height,
                            Width = picture.Width,
                            Image = downloadedData
                        };
                        // Save the img in the database
                        _pictureService.AddGifAnimatedToDB(newDbPic);
                        ViewBag.Message = "The Picture Has Been Saved Successfully in your Profile!";
                    }
                }
            }
            catch (System.Exception)
            {
                ViewBag.Message = "Unexpected error when saving the Picture in the Database. Try again later!";
            }
            return View();
        }


        /// <summary>
        /// Controllers which will eliminate a picture not longer wanted from the user profile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(string id)
        {
            try
            {
                int picId = Convert.ToInt32(id);
                var model = new ObjView.Picture();
                if (picId > 0)
                {
                    // Calling the DB context to delet the picture
                    _pictureService.DeleteGifAnimetedFromDB(picId);
                }
                ViewBag.IsError = false;
                ViewBag.Message = "Category deleted sucessfully!";
                return View("Common");
            }
            catch (Exception)
            {
                ViewBag.IsError = true;
                ViewBag.Message = $"Unexpected error ocurred while Deleting the Category for user: '{GetUserEmail()}'. Try again later!";
                return RedirectToAction(nameof(Index));
            }
        }


        /// <summary>
        /// Controller in charge of displaying the picture to make it available for editing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(string id)
        {
            PictureCategoryViewModel model = new PictureCategoryViewModel();
            try
            {
                int picId = Convert.ToInt32(id);
                if (picId > 0)
                {
                    // Get the picture by Id and User Email coming from Azure
                    model.Picture = ObjectTransformations.TransformDbtoViewObj(_pictureService.GetPictureByUserAndId(GetUserEmail(), picId));
                }
                // Existing Categories saved previously by the User
                var categories = _categoryService.GetCategoriesByUser(GetUserEmail());                
                if (categories != null)
                {
                    // Convert DB object to View object
                    foreach (var item in categories)
                    {
                        model.UserCategories.Add(ObjectTransformations.TransformDbtoViewObj(item));
                    }
                }
                return View(model);
            }
            catch (Exception)
            {
                model.IsError = true;
                model.Message = $"Unexpected error ocurred while Retrieving Category for user: '{GetUserEmail()}'. Try again later!";
                return View(model);
            }
        }


        /// <summary>
        /// Controller in charge of saving the changes made to the picture on the UI
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ObjView.Picture picture)
        {
            try
            {
                if (picture != null && ModelState.IsValid)
                {
                    var newDbPic = ObjectTransformations.TransformViewToDbObj(picture);
                    // Save the img in the database
                    _pictureService.UpdateGifAnimatedToDB(newDbPic);
                    ViewBag.Message = "The Picture Has Been Saved Successfully in your Profile!";
                    return View("Common");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {
                ViewBag.Message = "Unexpected error when saving the Picture in the Database. Try again later!";
                return RedirectToAction(nameof(Index));
            }            
        }

    }
}