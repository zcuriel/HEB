using GiphyA.Connector.Dtos;
using System.Threading.Tasks;

namespace GiphyA.Connector.Interfaces
{    
    interface IGetterGiphyAApi
    {

        /// <summary>
        /// Interface method definition to implement the Giphy API call
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        Task<GiphyASearchResult> GetGifImagesByCriteriaAsync(string searchCriteria);
    }
}
