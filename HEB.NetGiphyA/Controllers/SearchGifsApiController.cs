using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Models;
using HEB.NetGiphyA.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HEB.NetGiphyA.Controllers
{
    [Authorize]
    [Route("api/searchagifs")]
    public class SearchGifsApiController : Controller
    {
        private IGiphyASearchService _giphyAService;

        public SearchGifsApiController(IGiphyASearchService giphyAService)
        {
            _giphyAService = giphyAService;
        }

        /// <summary>
        /// Search the Animated Gifs from Giphy API
        /// </summary>
        /// <returns> Animated Gif collection</returns>
        [HttpGet]
        public IActionResult SearchAnimatedGifs(string searchText, int searchLimit, string language)
        {
            SearchResultViewModel model = new SearchResultViewModel();
            var result = _giphyAService.GetGifsByCriteria(searchText, searchLimit, language);
            if (result != null)
            {
                foreach (var item in result.Data)
                {
                    if (item != null)
                    {
                        model.Pictures.Add(new Picture()
                        {
                            FileName = getFileFromSourceUrl(item.BitlyGifUrl),
                            SourceUrl = item.BitlyGifUrl,
                            Height = Convert.ToInt32(item.Images?.Downsized?.Height),
                            Width = Convert.ToInt32(item.Images?.Downsized?.Width)                            
                        });
                    }
                }
            }
            return Json(model);
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
