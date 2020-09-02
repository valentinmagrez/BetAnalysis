using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnibetClient.DTO
{
    public class BetsHistoryDto
    {
        [JsonProperty("bettingHistoryItems")]
        public List<BetDto> Bets { get; set; }

        [JsonProperty("phHasNext")]
        public bool HasNextPage { get; set; }

        [JsonProperty("phCurrentPagePage")]
        public int CurrentPage { get; set; }
    }
}
