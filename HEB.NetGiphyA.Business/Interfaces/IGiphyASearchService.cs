using GiphyA.Connector.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HEB.NetGiphyA.Business.Interfaces
{
    public interface IGiphyASearchService
    {
        /// <summary>
        /// GetGifsByCriteria   :   Call the Giphy API to retrive the picture that meets the search criteria
        /// </summary>  
        /// <param name="searchText"></param>
        /// <param name="numResults"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        GiphyASearchResult GetGifsByCriteria(string searchText, int numResults, string language);
    }
}
