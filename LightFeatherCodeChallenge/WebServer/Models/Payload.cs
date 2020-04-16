using Newtonsoft.Json;

namespace WebServer.Models
{
    [JsonObject]
    public class Payload
    {
        [JsonProperty]
        public int Shift { get; set; }
        [JsonProperty]
        public string Message { get; set; }
    }

}
