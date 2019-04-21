using HEB.NetGiphyA.Business.Interfaces;
using PicDB = HEB.NetGiphyA.Data.Objects;
using PicWeb = HEB.NetGiphyA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HEB.NetGiphyA.ViewModels;

namespace HEB.NetGiphyA.Controllers
{
    [Authorize]
    public class PictureController : UserInfoController
    {
        private IPictureService _pictureService;

        public PictureController(IPictureService pictureService) : base()
        {
            _pictureService = pictureService;
        }

        /// <summary>
        /// Search the Animated Gifs from Giphy API
        /// </summary>
        /// <returns> Animated Gif collection</returns>
        [HttpGet]
        public IActionResult Index([FromQuery] PicWeb.Picture picture)
        {
            
            //PictureCategory model = new PictureCategory(picture);
            return View(picture);
        }

        [HttpPost]
        public IActionResult Save([FromBody] PicWeb.Picture picture)
        {
            
            return null;
        }

    }
}