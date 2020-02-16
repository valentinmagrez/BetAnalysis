using Newtonsoft.Json;

namespace UnibetService.UnibetApi.DTO
{
    public class BetDetailsDto
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("selectionName")]
        public string Selection { get; set; }

        [JsonProperty("marketName")]
        public string Name { get; set; }

        [JsonProperty("sportType")]
        public string Sport { get; set; }
    }
}
