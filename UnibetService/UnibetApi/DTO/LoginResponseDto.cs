using Newtonsoft.Json;

namespace UnibetService.UnibetApi.DTO
{
    public class LoginResponseDto
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }
}
