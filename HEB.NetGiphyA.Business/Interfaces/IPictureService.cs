using HEB.NetGiphy.Data.Objects;
using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IEnumerable<Picture> GetAllGifsByUserAndCategory(string userId, int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        void AddEditGifAnimatedToDB(Picture picture);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        void DeleteGifAnimetedFromDB(Picture picture);
    }
}
