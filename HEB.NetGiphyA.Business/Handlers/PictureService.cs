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


        /// <summary>
        /// Method implementation to Add a new picture into the database
        /// </summary>
        /// <param name="picture"></param>
        public void AddGifAnimatedToDB(Picture picture)
        {
            _pictureContext.Add(picture);
            _pictureContext.SaveChanges();            
        }


        /// <summary>
        /// Method implmentation to delete an existing picture from the database
        /// </summary>
        /// <param name="pictureId"></param>
        public void DeleteGifAnimetedFromDB(int pictureId)
        {
            _pictureContext.Remove(new Picture() { PictureId = pictureId });
            _pictureContext.SaveChanges();
        }


        /// <summary>
        /// Method implmentation to Update the whole picture record
        /// </summary>
        /// <param name="picture"></param>
        public void EditGifAnimatedToDB(Picture picture)
        {
            _pictureContext.Entry(picture).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _pictureContext.SaveChanges();
        }


        /// <summary>
        /// Method implmentation to get all the saved pictures in the user profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Picture> GetAllGifsByUser(string userId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Method implmentation to get all the saved pictures in the user profile by a specific category
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IEnumerable<Picture> GetAllGifsByUserAndCategory(string userEmail, int categoryId)
        {
            return _pictureContext.Pictures.Where(p => p.UserEmail == userEmail && p.CategoryId == categoryId).OrderBy(p => p.Name);
        }


        /// <summary>
        /// Method implmentation to get a specific picture based on the user requested and the Id
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        public Picture GetPictureByUserAndId(string userEmail, int pictureId)
        {
            return _pictureContext.Pictures.Where(p => p.UserEmail == userEmail && p.PictureId == pictureId).FirstOrDefault();
        }


        /// <summary>
        /// Method implmentation to update only the picture fields allowed in the UI
        /// </summary>
        /// <param name="picture"></param>
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
