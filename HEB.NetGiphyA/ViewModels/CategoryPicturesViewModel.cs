using HEB.NetGiphyA.Models;

namespace HEB.NetGiphyA.ViewModels
{
    public class CategoryPicturesViewModel : ParentViewModel
    {
        public CategoryPicturesViewModel(PictureViewModel pictureModel)
        {
            Pictures = pictureModel;
        }

        public CategoryPicturesViewModel(Category category) : this(new PictureViewModel())
        {
            Category = category;            
        }

        public CategoryPicturesViewModel(Category category, PictureViewModel pictureModel)
        {
            Category = category;
            Pictures = pictureModel;
        }

        public CategoryPicturesViewModel() : this(new Category(), new PictureViewModel())
        {
        }

        // Category of the pictures
        public Category Category { get; set; }
        // All the picture related to a specific category above
        public PictureViewModel Pictures { get; set; }
    }
}
