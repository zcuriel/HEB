using HEB.NetGiphyA.Business.Interfaces;
using ObjDB = HEB.NetGiphyA.Data.Objects;
using ObjView = HEB.NetGiphyA.Models;
using HEB.NetGiphyA.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

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

        [HttpGet]
        public IActionResult AddEdit(string id = null)
        {
            var newCategory = new ObjView.Category();
            int categoryId = Convert.ToInt32(id);
            if (categoryId > 0)
            {
                var categoryDB = _categoryService.GetCategoryById(categoryId);
                if (categoryDB != null)
                {
                    newCategory.CategoryId = categoryDB.CategoryId;
                    newCategory.Name = categoryDB.Name;
                    newCategory.Description = categoryDB.Description;
                }
            }
            return View(newCategory);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddEdit(ObjView.Category model)
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
                return RedirectToAction(nameof(Index));
            } else
            {
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            int categoryId = Convert.ToInt32(id);
            if (categoryId > 0)
            {
                _categoryService.DeleteCategory(categoryId);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
