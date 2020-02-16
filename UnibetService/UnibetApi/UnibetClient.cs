using System.Net.Http;
using System.Threading.Tasks;
using UnibetService.UnibetApi.DTO;

namespace UnibetService.UnibetApi
{
    public class UnibetClient
    {
        private readonly HttpClient _client = new HttpClient();

        private const string BaseUri = "https://www.unibet.fr/zones/";
        
        public async Task<LoginResponseDto> Login(string username, string password, string birthDate)
        {
            const string uriSuffix = "loginbox/processLogin.json";
            var queryParams = $"username={username}&password={password}&dateOfBirth={birthDate}";

            var fullUri = $"{BaseUri}{uriSuffix}?{queryParams}";
            return await Post<LoginResponseDto>(fullUri);
        }

        private async Task<T> Post<T>(string uri)
        {
            var response = await _client.PostAsync(uri, null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }
    }
}
