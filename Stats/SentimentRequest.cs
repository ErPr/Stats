using Newtonsoft.Json;
using System.Collections.Generic;

namespace Stats
{

    public class SentimentRequest
    {
        [JsonProperty(PropertyName = "document")]
        public List<Document> Documents { get; set; }
    }

    public class Document
    {
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }

}
