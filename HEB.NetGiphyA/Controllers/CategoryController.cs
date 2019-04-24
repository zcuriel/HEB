using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using ObjDB = HEB.NetGiphyA.Data.Objects;
using ObjView = HEB.NetGiphyA.Models;

namespace HEB.NetGiphyA.Controllers
{
    [Authorize]
    public class CategoryController : UserInfoController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Generic index controller for the categories in case in the future will be require
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Controller that display the page for Add/Edit a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddEdit(string id = null)
        {
            var model = new ObjView.Category();
            try
            {
                int categoryId = Convert.ToInt32(id);
                if (categoryId > 0)
                {
                    // Edit a category (retrieve the object from the db)
                    var categoryDB = _categoryService.GetCategoryById(categoryId);
                    if (categoryDB != null)
                    {
                        model.CategoryId = categoryDB.CategoryId;
                        model.Name = categoryDB.Name;
                        model.Description = categoryDB.Description;
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
        /// Controller that invokes the category to be saved in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddEdit(ObjView.Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var catDb = ObjectTransformations.TransformViewToDbObj(model);
                    catDb.UserEmail = GetUserEmail();   // Azure user information
                    // Add/Update category in the db
                    _categoryService.AddEditCategory(catDb);
                    ViewBag.IsError = "false";
                    ViewBag.Message = "Category added/updated sucessfully!";
                    return RedirectToAction("Index", "Picture");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.IsError = true;
                ViewBag.Message = $"Unexpected error ocurred while Saving the Category for user: '{GetUserEmail()}'. Try again later!";
                return RedirectToAction("Index", "Picture");
            }

        }


        /// <summary>
        /// Controller that request the category to be deleted from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(string id)
        {
            try
            {
                int categoryId = Convert.ToInt32(id);
                var model = new ObjView.Category();
                if (categoryId > 0)
                {
                    _categoryService.DeleteCategory(categoryId);
                    ViewBag.IsError = false;
                    ViewBag.Message = "Category deleted sucessfully!";
                    return View();
                } else
                {
                    return RedirectToAction(nameof(Index), "Picture");
                }
            }
            catch (Exception)
            {
                ViewBag.IsError = true;
                ViewBag.Message = $"Unexpected error ocurred while Deleting the Category for user: '{GetUserEmail()}'. Try again later!";
                return RedirectToAction(nameof(Index), "Picture");
            }
        }
    }
}
