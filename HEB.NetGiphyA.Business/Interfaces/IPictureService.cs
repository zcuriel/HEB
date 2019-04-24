using HEB.NetGiphyA.Data.Objects;
using System.Collections.Generic;

namespace HEB.NetGiphyA.Business.Interfaces
{
    public interface IPictureService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Picture> GetAllGifsByUser(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IEnumerable<Picture> GetAllGifsByUserAndCategory(string userEmail, int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        Picture GetPictureByUserAndId(string userEmail, int pictureId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        void AddGifAnimatedToDB(Picture picture);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        void EditGifAnimatedToDB(Picture picture);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pictureId"></param>
        void DeleteGifAnimetedFromDB(int pictureId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        void UpdateGifAnimatedToDB(Picture picture);
    }
}
