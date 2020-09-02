using System;
using Dashboard.Models.Converters;
using Newtonsoft.Json;

namespace Dashboard.Models
{
    public class BetDto
    {

        [JsonProperty("date")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("stake")]
        public decimal Stake { get; set; }

        [JsonProperty("isFreeBets")]
        public bool IsFreeBet { get; set; }

        [JsonProperty("totalOdd")]
        public double? Odd { get; set; }

        [JsonProperty("totalReturn")]
        public decimal? TotalReturn { get; set; }

        public decimal? Benefits
        {
            get { return IsFreeBet ? TotalReturn : TotalReturn - Stake; }
        }
    }
}
