
using GiphyA.Connector.Dtos;
using GiphyA.Connector.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiphyA.Connector.ApiHandlers
{
    public class GetterGiphyAApi : IGetterGiphyAApi
    {
        public async Task<GiphyASearchResult> GetGifImagesByCriteriaAsync(string searchCriteria)
        {
            // Get the API Url
            const string giphyKey = "a7FTUA54ydSRaqAM4Zo276nkEoKureI2";     // H-E-B APP KEY
            const string apiUrl = "http://api.giphy.com/v1/gifs/search";    // API Call

            try
            {
                using (var client = new HttpClient())
                {
                    // search criteria will include the following parameters need from api, as follow:
                    // &q=<text>&limit=25&offset=0&rating=G&lang=en
                    // q => text to search from
                    // limit => number maximum of gif returned
                    // rating => gif rating
                    // lang => language
                    var url = new Uri($"{apiUrl}?api_key={giphyKey}&{searchCriteria}");
                    var response = await client.GetAsync(url);
                    string json;
                    using (var content = response.Content)
                    {
                        json = await content.ReadAsStringAsync();
                    }

                    return JsonConvert.DeserializeObject<GiphyASearchResult>(json);
                }
                
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
