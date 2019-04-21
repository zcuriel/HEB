using HEB.GiphyA.Connector.Dtos;
using Newtonsoft.Json;

namespace GiphyA.Connector.Dtos
{
    public class GiphyAImage
    {
        [JsonProperty("original_still")]
        public OriginalStill OriginalStill { get; set; }

        [JsonProperty("downsized")]
        public Downsized Downsized { get; set; }

        [JsonProperty("downsized_still")]
        public DownsizedStill DownsizedStill { get; set; }
    }
}