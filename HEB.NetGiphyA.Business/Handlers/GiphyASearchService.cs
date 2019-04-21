using GiphyA.Connector;
using GiphyA.Connector.Dtos;
using HEB.NetGiphyA.Business.Interfaces;
using System.Text;

namespace HEB.NetGiphyA.Business.Handlers
{
    public class GiphyASearchService : IGiphyASearchService
    {
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
