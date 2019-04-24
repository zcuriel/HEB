using HEB.NetGiphyA.Data.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HEB.NetGiphyA.Business.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get categories of Pictures saved in the user profile
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        IEnumerable<Category> GetCategoriesByUser(string userEmail);

        /// <summary>
        /// Get a specific category by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category GetCategoryById(int categoryId);

        /// <summary>
        /// (Add a new) / (Update an existing) Category of Pictures
        /// </summary>
        /// <param name="category"></param>
        int AddEditCategory(Category category);

        /// <summary>
        /// Delete an empty category
        /// </summary>
        /// <param name="categoryId"></param>
        void DeleteCategory(int categoryId);
    }
}
