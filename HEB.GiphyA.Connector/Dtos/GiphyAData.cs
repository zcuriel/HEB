using Newtonsoft.Json;

namespace GiphyA.Connector.Dtos
{
    public class GiphyAData
    {
        [JsonProperty("bitly_gif_url")]
        public string BitlyGifUrl { get; set; }

        [JsonProperty("images")]
        public GiphyAImage Images { get; set; }
    }
}