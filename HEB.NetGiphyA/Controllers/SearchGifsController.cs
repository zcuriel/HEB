using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Models;
using HEB.NetGiphyA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HEB.NetGiphyA.Controllers
{
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
            SearchResultView model = new SearchResultView();
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
                            Size = Convert.ToInt32(item.Images?.Downsized?.Size),
                            Height = Convert.ToInt32(item.Images?.Downsized?.Height),
                            Width = Convert.ToInt32(item.Images?.Downsized?.Width)
                        });
                    }
                }
            }
            return View(model);
        }

        private string getFileFromSourceUrl(string urlSource)
        {
            string retStr = string.Empty;
            if (!string.IsNullOrEmpty(urlSource) && !string.IsNullOrWhiteSpace(urlSource))
            {
                int lastIndexOf = urlSource.LastIndexOf("/");
                if (lastIndexOf > 0)
                {
                    retStr = urlSource.Substring(++lastIndexOf);
                }
            }
            return retStr;
        }

    }
}
