using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Data;
using HEB.NetGiphyA.Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HEB.NetGiphyA.Business.Handlers
{
    public class CategoryService : ICategoryService
    {
        private NetGiphyADbContext _dbContext;

        public CategoryService(NetGiphyADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEditCategory(Category category)
        {
            if (category.CategoryId > 0)
            {
                // Update request
                _dbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            } else
            {
                // New category
                _dbContext.Add(category);
            }            
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            _dbContext.Remove(new Category() { CategoryId = categoryId });
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategoriesByUser(string userEmail)
        {
            return _dbContext.Categories.Where(c => c.UserEmail == userEmail).OrderBy(c => c.Name);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
        }
    }
}
