using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnibetService.Utils.Converters;

namespace UnibetClient.DTO
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
        public double? Odd { get; set; }

        [JsonProperty("totalReturn")]
        public decimal? TotalReturn { get; set; }

        [JsonProperty("externalReference")]
        public string BetNumber { get; set; }

        [JsonProperty("isFreeBets")]
        public bool IsFreeBet { get; set; }

        public bool IsFirstBet => BetNumber.Split('/')[0] == "1";

        public decimal? Benefit => IsFreeBet? TotalReturn : TotalReturn - Stake;
    }
}
