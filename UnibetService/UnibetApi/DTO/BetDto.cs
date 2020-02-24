using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnibetService.Utils.Converters;

namespace UnibetService.UnibetApi.DTO
{
    public class BetDto
    {
        [JsonProperty("IDFOBet")]
        public float CustomId { get; set; }

        [JsonProperty("date")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("betlegs")]
        public List<BetDetailsDto> BetsDetailsDtos { get; set; }

        [JsonProperty("stake")]
        public decimal Stake { get; set; }

        [JsonProperty("totalOdd")]
        public double Odd { get; set; } 
    }
}
