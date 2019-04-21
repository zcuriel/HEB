using HEB.NetGiphyA.Models;
using System.Collections.Generic;

namespace HEB.NetGiphyA.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Categories = new List<Category>();
        }

        public List<Category> Categories { get; set; }
    }
}
