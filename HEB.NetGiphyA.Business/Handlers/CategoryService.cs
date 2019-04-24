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


        /// <summary>
        /// EF implementation to (add new) / (update an existing) category for pictures
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int AddEditCategory(Category category)
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
            return category.CategoryId;
        }


        /// <summary>
        /// EF implementation to delete an existing and empty category
        /// </summary>
        /// <param name="categoryId"></param>
        public void DeleteCategory(int categoryId)
        {
            _dbContext.Remove(new Category() { CategoryId = categoryId });
            _dbContext.SaveChanges();
        }


        /// <summary>
        /// EF implementation to get all the categories in the user profile  (user email is coming from Azure)
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public IEnumerable<Category> GetCategoriesByUser(string userEmail)
        {
            return _dbContext.Categories.Where(c => c.UserEmail == userEmail).OrderBy(c => c.Name);
        }


        /// <summary>
        /// EF implementation to get a specific category by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
        }
    }
}
