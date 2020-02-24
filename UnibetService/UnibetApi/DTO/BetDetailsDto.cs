using System;
using Newtonsoft.Json;
using UnibetService.Utils.Converters;

namespace UnibetService.UnibetApi.DTO
{
    public class BetDetailsDto
    {
        [JsonProperty("eventDate")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime EventDate { get; set; }

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
