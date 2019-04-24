using HEB.NetGiphyA.Data.Objects;
using System.Collections.Generic;

namespace HEB.NetGiphyA.Business.Interfaces
{
    public interface IPictureService
    {
        /// <summary>
        /// Method definition to get all the Users Gifs saved in the database (Azure)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Picture> GetAllGifsByUser(string userEmail);

        /// <summary>
        /// Method definition to get All the User Gifs saved in the database by Category (Azure)
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IEnumerable<Picture> GetAllGifsByUserAndCategory(string userEmail, int categoryId);

        /// <summary>
        /// Method definition to get one specific Picture based on the Id
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        Picture GetPictureByUserAndId(string userEmail, int pictureId);

        /// <summary>
        /// Method defintion to Add new picture into the user profile (database)
        /// </summary>
        /// <param name="picture"></param>
        void AddGifAnimatedToDB(Picture picture);

        /// <summary>
        /// Method defintion to Update an existing picture the whole record (database)
        /// </summary>
        /// <param name="picture"></param>
        void EditGifAnimatedToDB(Picture picture);

        /// <summary>
        /// Method defintion to delete an existing picture from the user profile (database)
        /// </summary>
        /// <param name="pictureId"></param>
        void DeleteGifAnimetedFromDB(int pictureId);

        /// <summary>
        ///Method defintion to Update an existing picture changed in the UI (database)
        /// </summary>
        /// <param name="picture"></param>
        void UpdateGifAnimatedToDB(Picture picture);
    }
}
