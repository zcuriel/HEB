namespace HEB.NetGiphyA.Models
{
    public class CategoryPicturesModel
    {
        public CategoryPicturesModel(PictureModel pictureModel)
        {
            Pictures = pictureModel;
        }

        public CategoryPicturesModel(Category category) : this(new PictureModel())
        {
            Category = category;            
        }

        public CategoryPicturesModel(Category category, PictureModel pictureModel)
        {
            Category = category;
            Pictures = pictureModel;
        }

        public CategoryPicturesModel() : this(new Category(), new PictureModel())
        {
        }

        public Category Category { get; set; }

        public PictureModel Pictures { get; set; }
    }
}
