using Newtonsoft.Json;

namespace GiphyA.Connector.Dtos
{
    public class GiphyAImage
    {
        [JsonProperty("downsized")]
        public Downsized Downsized { get; set; }

        [JsonProperty("downsized_still")]
        public DownsizedStill DownsizedStill { get; set; }
    }
}