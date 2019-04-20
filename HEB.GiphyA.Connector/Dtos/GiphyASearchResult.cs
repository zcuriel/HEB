using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyA.Connector.Dtos
{
    public class GiphyASearchResult
    {
        [JsonProperty("data")]
        public IEnumerable<GiphyAData> Data { get; set; }
    }
}
