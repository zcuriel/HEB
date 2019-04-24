using GiphyA.Connector.ApiHandlers;
using GiphyA.Connector.Dtos;
using System.Threading.Tasks;

namespace GiphyA.Connector
{
    public class GiphyAApiSearcher
    {

        /// <summary>
        /// Public Static method manages to invoke up to twice the API if the first call failed for any reason
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        public static GiphyASearchResult GetImagesByCriteria(string searchCriteria)
        {
            if (string.IsNullOrEmpty(searchCriteria)) return null;
            // Call the API with the search criteria
            var response = ProcessSearch(searchCriteria).GetAwaiter().GetResult();
            // Call the API for second time in case of unexpected error ocurred in the first try
            if (response == null) response = ProcessSearch(searchCriteria).GetAwaiter().GetResult();            
            return response;
        }


        /// <summary>
        /// Process the call to hit the API
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        private static async Task<GiphyASearchResult> ProcessSearch(string searchCriteria)
        {            
            var gifSearcher = new GetterGiphyAApi();
            return await gifSearcher.GetGifImagesByCriteriaAsync(searchCriteria);            
        }
    }
}
