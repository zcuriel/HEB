using GiphyA.Connector.Dtos;
using System.Threading.Tasks;

namespace GiphyA.Connector.Interfaces
{
    interface IGetterGiphyAApi
    {
        Task<GiphyASearchResult> GetGifImagesByCriteriaAsync(string searchCriteria);
    }
}
