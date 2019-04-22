using HEB.NetGiphyA.Models;
using System.Collections.Generic;

namespace HEB.NetGiphyA.ViewModels
{
    public class PictureCategoryViewModel
    {
        public PictureCategoryViewModel(Picture picture, IEnumerable<Category> categories)
        {
            Picture = picture;
            UserCategories = categories;
        }

        public Picture Picture { get; set; }
        public IEnumerable<Category> UserCategories { get; set; }
    }
}
