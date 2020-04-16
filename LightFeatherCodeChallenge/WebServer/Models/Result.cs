using Newtonsoft.Json;

namespace WebServer.Models
{
    [JsonObject]
    public class Result
    {
        [JsonProperty]

        public string EncodedMessage { get; set; }
    }
}
