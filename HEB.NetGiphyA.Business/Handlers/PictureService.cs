using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Data;
using HEB.NetGiphyA.Data.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HEB.NetGiphyA.Business.Handlers
{
    public class PictureService : IPictureService
    {
        private NetGiphyADbContext _pictureContext;

        public PictureService(NetGiphyADbContext pictureContext)
        {
            _pictureContext = pictureContext;
        }

        public void AddGifAnimatedToDB(Picture picture)
        {
            _pictureContext.Add(picture);
            _pictureContext.SaveChanges();            
        }

        public void DeleteGifAnimetedFromDB(int pictureId)
        {
            _pictureContext.Remove(new Picture() { PictureId = pictureId });
            _pictureContext.SaveChanges();
        }

        public void EditGifAnimatedToDB(Picture picture)
        {
            _pictureContext.Entry(picture).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _pictureContext.SaveChanges();
        }

        public IEnumerable<Picture> GetAllGifsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Picture> GetAllGifsByUserAndCategory(string userEmail, int categoryId)
        {
            return _pictureContext.Pictures.Where(p => p.UserEmail == userEmail && p.CategoryId == categoryId).OrderBy(p => p.Name);
        }

        public Picture GetPictureByUserAndId(string userEmail, int pictureId)
        {
            return _pictureContext.Pictures.Where(p => p.UserEmail == userEmail && p.PictureId == pictureId).FirstOrDefault();
        }

        public void UpdateGifAnimatedToDB(Picture picture)
        {
            // Update request
            var entity = _pictureContext.Pictures.Find(picture.PictureId);

            // Only the following fields are allowed to modify in the page
            entity.CategoryId = picture.CategoryId;
            entity.Name = picture.Name;
            entity.Description = picture.Description;

            _pictureContext.SaveChanges();
        }
    }
}
