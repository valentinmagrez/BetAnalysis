using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UnibetService.UnibetApi.DTO
{
    public class BetDto
    {
        [JsonProperty("betlegs")]
        public List<BetDetailsDto> BetsDetailsDtos { get; set; }

        [JsonProperty("stake")]
        public decimal Stake { get; set; }

        [JsonProperty("totalOdd")]
        public double Odd { get; set; } 
    }
}
