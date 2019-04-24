using DbObj = HEB.NetGiphyA.Data.Objects;
using ViewObj = HEB.NetGiphyA.Models;

namespace HEB.NetGiphyA.Util
{
    public static class ObjectTransformations
    {
        public static ViewObj.Picture TransformDbtoViewObj(DbObj.Picture picture)
        {
            ViewObj.Picture newPicture = null;
            if (picture != null)
            {
                newPicture = new ViewObj.Picture
                {
                    PictureId = picture.PictureId,
                    CategoryId = picture.CategoryId,
                    Name = picture.Name,
                    Description = picture.Description,
                    FileName = picture.FileName,
                    SourceUrl = picture.SourceUrl,
                    Height = picture.Height,
                    Width = picture.Width
                };
            }
            return newPicture; 
        }

        public static ViewObj.Category TransformDbtoViewObj(DbObj.Category category)
        {
            ViewObj.Category newCategory = null;
            if (category != null)
            {
                newCategory = new ViewObj.Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
            }

            return newCategory;
        }

        public static DbObj.Picture TransformViewToDbObj(ViewObj.Picture picture)
        {
            DbObj.Picture newPicture = null;
            if (picture != null)
            {
                newPicture = new DbObj.Picture
                {
                    PictureId = picture.PictureId,
                    CategoryId = picture.CategoryId,
                    Name = picture.Name,
                    Description = picture.Description,
                    FileName = picture.FileName,
                    SourceUrl = picture.SourceUrl,
                    Height = picture.Height,
                    Width = picture.Width,
                    Image = null,                   // Field that needs to be setup from outside the transformation
                    UserEmail = string.Empty        // Field that needs to be setup from outside the transformation
                };
            }
            return newPicture;
        }

        public static DbObj.Category TransformViewToDbObj(ViewObj.Category category)
        {
            DbObj.Category newCategory = null;
            if (category != null)
            {
                newCategory = new DbObj.Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                    UserEmail = string.Empty        // Field that needs to be setup from outside the transformation
                };
            }
            return newCategory;
        }
    }
}
