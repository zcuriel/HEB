using DbObj = HEB.NetGiphyA.Data.Objects;
using ViewObj = HEB.NetGiphyA.Models;

namespace HEB.NetGiphyA.Util
{
    public static class ObjectTransformations
    {
        /// <summary>
        /// Transform a picture database object to a Category view Obj
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Transform a category database object to a Category view Obj
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Transform a user database object to a User view Obj
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static ViewObj.User TransformDbtoViewObj(DbObj.User user)
        {
            ViewObj.User newUser = null;
            if (user != null)
            {
                newUser = new ViewObj.User
                {
                    UserId = user.UserId,
                    UserEmail = user.UserEmail,
                    Name = user.Name
                };
            }

            return newUser;
        }

        /// <summary>
        /// Transform a picture view object to a Category EF Obj
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Transform a category view object to a Category EF Obj
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Transform a user view object to a User EF Obj
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static DbObj.User TransformViewToDbObj(ViewObj.User user)
        {
            DbObj.User newUser = null;
            if (user != null)
            {
                newUser = new DbObj.User
                {
                    UserId = user.UserId,
                    UserEmail = user.UserEmail,
                    Name = user.Name
                };
            }

            return newUser;
        }

    }
}
