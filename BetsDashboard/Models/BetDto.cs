using System;
using Newtonsoft.Json;
using UnibetService.Utils.Converters;

namespace BetsDashboard.Models
{
    public class BetDto
    {

        [JsonProperty("date")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("stake")]
        public decimal Stake { get; set; }

        [JsonProperty("totalOdd")]
        public double? Odd { get; set; }

        [JsonProperty("totalReturn")]
        public decimal? TotalReturn { get; set; }
    }
}
