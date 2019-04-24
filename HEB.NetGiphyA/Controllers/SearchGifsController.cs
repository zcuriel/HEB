using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Models;
using HEB.NetGiphyA.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HEB.NetGiphyA.Controllers
{
    [Authorize]
    public class SearchGifsController : Controller
    {
        private IGiphyASearchService _giphyAService;

        public SearchGifsController(IGiphyASearchService giphyAService)
        {
            _giphyAService = giphyAService;
        }

        /// <summary>
        /// Search Index Controller
        /// </summary>
        /// <returns> Index view</returns>        
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Search the Animated Gifs from Giphy API
        /// </summary>
        /// <returns> Animated Gif collection</returns>        
        [HttpGet]        
        public IActionResult SearchAnimatedGifs(string searchText, int searchLimit, string language)
        {
            PictureViewModel model = new PictureViewModel();
            try
            {
                var result = _giphyAService.GetGifsByCriteria(searchText, searchLimit, language);
                if (result != null)
                {
                    foreach (var item in result.Data)
                    {
                        if (item != null)
                        {
                            model.Pictures.Add(new Picture()
                            {
                                SourceUrl = item.Images?.OriginalStill?.Url,
                                FileName = item.Images?.Downsized?.Url,
                                Height = Convert.ToInt32(item.Images?.Downsized?.Height),
                                Width = Convert.ToInt32(item.Images?.Downsized?.Width)
                            });
                        }
                    }
                }
                return View(model);
            }
            catch (Exception)
            {
                model.IsError = true;
                model.Message = "Unexpected error ocurred while retrieving Animated Gifs from Giphy Website. Try again later!";
                return View(model);
            } 
        }    
    }
}
