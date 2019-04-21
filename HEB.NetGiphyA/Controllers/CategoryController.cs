using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Models;
using HEB.NetGiphyA.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            CategoryViewModel model = new CategoryViewModel();
            var results = _categoryService.GetCategoriesByUser(GetUserEmail());
            if (results != null)
            {
                foreach (var item in results)
                {
                    model.Categories.Add(new Category()
                    {
                        CategoryId = item.CategoryId,
                        Name = item.Name,
                        Description = item.Description
                    });
                }
            }
            return View(model);
        }
    }
}
