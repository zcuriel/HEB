using HEB.NetGiphy.Data.Objects;
using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Data;
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
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategoriesByUser(string userEmail)
        {
            return _dbContext.Categories.Where(c => c.UserEmail == userEmail).OrderBy(c => c.Name);
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
