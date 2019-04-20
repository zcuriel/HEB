using Newtonsoft.Json;

namespace GiphyA.Connector.Dtos
{
    public class DownsizedStill
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }
}