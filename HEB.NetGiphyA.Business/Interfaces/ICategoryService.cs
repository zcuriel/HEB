using HEB.NetGiphyA.Data.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HEB.NetGiphyA.Business.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        IEnumerable<Category> GetCategoriesByUser(string userEmail);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category GetCategoryById(int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        void AddEditCategory(Category category);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        void DeleteCategory(int categoryId);
    }
}
