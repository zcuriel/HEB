using Newtonsoft.Json;

namespace HEB.GiphyA.Connector.Dtos
{
    public class OriginalStill
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }
}
