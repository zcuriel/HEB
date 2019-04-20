using System;
using System.Configuration;
using System.Net.Http;
using GiphyA.Connector.ApiHandlers;
using GiphyA.Connector.Dtos;
using System.Threading.Tasks;

namespace GiphyA.Connector
{
    public class GiphyAApiSearcher
    {
        public static GiphyASearchResult GetImagesByCriteria(string searchCriteria)
        {
            // Call the API with the search criteria
            var response = ProcessSearch(searchCriteria).GetAwaiter().GetResult();
            // Call the API for second time in case of unexpected error ocurred in the first try
            if (response == null) response = ProcessSearch(searchCriteria).GetAwaiter().GetResult();            
            return response;
        }

        private static async Task<GiphyASearchResult> ProcessSearch(string searchCriteria)
        {
            
            var gifSearcher = new GetterGiphyAApi();
            return await gifSearcher.GetGifImagesByCriteriaAsync(searchCriteria);            
        }
    }
}
