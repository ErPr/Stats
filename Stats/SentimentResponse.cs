using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stats
{

    public class SentimentResponse
    {
        [JsonProperty(PropertyName = "documents")]
        public List<Sentiment> Sentiments { get; set; }
        [JsonProperty(PropertyName = "errors")]
        public List<object> Errors { get; set; }
    }

    public class Sentiment
    {
        [JsonProperty(PropertyName = "score")]
        public float Score{ get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }

}
