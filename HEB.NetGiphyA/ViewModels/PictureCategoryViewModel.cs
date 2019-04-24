
using HEB.NetGiphyA.Models;
using System.Collections.Generic;

namespace HEB.NetGiphyA.ViewModels
{
    public class PictureCategoryViewModel : ParentViewModel
    {
        public PictureCategoryViewModel(Picture picture, List<Category> categories)
        {
            Picture = picture;
            UserCategories = categories;
        }

        public PictureCategoryViewModel() : this(new Picture(), new List<Category>())
        {
        }

        // Picture to save into the database
        public Picture Picture { get; set; }
        // Existing Categories on the profile user
        public List<Category> UserCategories { get; set; }
    }
}
