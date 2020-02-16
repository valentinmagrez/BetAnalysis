using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnibetService.UnibetApi.DTO
{
    public class BetsHistoryDto
    {
        [JsonProperty("bettingHistoryItems")]
        public List<BetDto> Bets { get; set; }
    }
}
