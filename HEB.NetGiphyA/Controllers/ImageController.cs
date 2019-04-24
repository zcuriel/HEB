using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace HEB.NetGiphyA.Controllers
{
    public class ImageController : UserInfoController
    {
        private IPictureService _pictureService;

        public ImageController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public FileStreamResult GetFile(string pictureId) 
        {
            try
            {
                var picture = _pictureService.GetPictureByUserAndId(GetUserEmail(), Convert.ToInt32(pictureId));
                Stream imgStream = new MemoryStream(picture?.Image);
                return new FileStreamResult(imgStream, Constants.GIPHY_CONTENT_TYPE);
            }
            catch (System.Exception)
            {
                return null;                
            }
        }
    }
}
