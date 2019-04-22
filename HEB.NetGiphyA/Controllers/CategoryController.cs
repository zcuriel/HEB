using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.ViewModels;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            CategoryViewModel model = new CategoryViewModel();
            try
            {
                var results = _categoryService.GetCategoriesByUser(GetUserEmail());
                if (results != null)
                {
                    foreach (var item in results)
                    {
                        model.Categories.Add(new ObjView.Category()
                        {
                            CategoryId = item.CategoryId,
                            Name = item.Name,
                            Description = item.Description
                        });
                    }
                }
                return View(model);
            }
            catch (Exception)
            {
                model.IsError = true;
                model.Message = $"Unexpected error ocurred while retrieving list of categories for user: '{GetUserEmail()}'. Try again later!";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult AddEdit(string id = null)
        {
            var model = new ObjView.Category();
            try
            {
                int categoryId = Convert.ToInt32(id);
                if (categoryId > 0)
                {
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

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddEdit(ObjView.Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var catDb = new ObjDB.Category()
                    {
                        CategoryId = model.CategoryId,
                        Name = model.Name,
                        Description = model.Description,
                        UserEmail = GetUserEmail()
                    };

                    _categoryService.AddEditCategory(catDb);
                    ViewBag.IsError = "false";
                    ViewBag.Message = "Category added/updated sucessfully!";
                    return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Index));
            }

        }

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
                }
                ViewBag.IsError = false;
                ViewBag.Message = "Category deleted sucessfully!";
                return View();
            }
            catch (Exception)
            {
                ViewBag.IsError = true;
                ViewBag.Message = $"Unexpected error ocurred while Deleting the Category for user: '{GetUserEmail()}'. Try again later!";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
