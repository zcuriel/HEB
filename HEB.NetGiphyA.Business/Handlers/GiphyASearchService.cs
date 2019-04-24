using GiphyA.Connector;
using GiphyA.Connector.Dtos;
using HEB.NetGiphyA.Business.Interfaces;
using System.Text;

namespace HEB.NetGiphyA.Business.Handlers
{
    public class GiphyASearchService : IGiphyASearchService
    {

        /// <summary>
        /// Function which helps to build the QueryString to hit the Giphy API
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddParamToSearchCriteria(StringBuilder criteria, string key, string value) {
            
            if ((!string.IsNullOrEmpty(value)) && (!string.IsNullOrWhiteSpace(value)))
            {
                if (criteria.Length > 0)
                {
                    criteria.Append("&");
                }
                criteria.Append(key + "=" + value);
            }
        }


        /// <summary>
        /// Function which helps to build the QueryString to hit the Giphy API 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddParamToSearchCriteria(StringBuilder criteria, string key, int value)
        {
            if (value > 0)
            {
                if (criteria.Length > 0)
                {
                    criteria.Append("&");
                }
                criteria.Append(key + "=" + value.ToString());
            }
        }


        /// <summary>
        /// Service Invokes the Giphy API call based on the criteria
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="numResults"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public GiphyASearchResult GetGifsByCriteria(string searchText, int numResults, string language)
        {
            // Building the search criteria
            StringBuilder searchCriteria = new StringBuilder();
            // Add Text to Search Criteria
            AddParamToSearchCriteria(searchCriteria, Constants.SEARCH_TEXT, searchText);
            // Add Number of Results to Search Criteria
            AddParamToSearchCriteria(searchCriteria, Constants.SEARCH_LIMIT, numResults);
            // Add Offset to the Search Criteria
            AddParamToSearchCriteria(searchCriteria, Constants.SEARCH_OFFSET, Constants.OFFSET_VALUE);
            // Add Rating to the Search Criteria
            AddParamToSearchCriteria(searchCriteria, Constants.SEARCH_RATING, Constants.GIF_RATING);
            // Add Languague to the Search Criteria
            AddParamToSearchCriteria(searchCriteria, Constants.SEARCH_LANGUAGUE, language);
            
            return GiphyAApiSearcher.GetImagesByCriteria(searchCriteria.ToString());
        }
    }
}
