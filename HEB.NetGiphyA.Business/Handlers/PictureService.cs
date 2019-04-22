using HEB.NetGiphyA.Data.Objects;
using HEB.NetGiphyA.Business.Interfaces;
using System;
using System.Collections.Generic;

namespace HEB.NetGiphyA.Business.Handlers
{
    public class PictureService : IPictureService
    {
        public void AddEditGifAnimatedToDB(Picture picture)
        {
            throw new NotImplementedException();
        }

        public void DeleteGifAnimetedFromDB(Picture picture)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Picture> GetAllGifsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Picture> GetAllGifsByUserAndCategory(string userId, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
