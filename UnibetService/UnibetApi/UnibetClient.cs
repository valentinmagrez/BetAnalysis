using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnibetService.UnibetApi
{
    public class UnibetClient
    {
        private readonly HttpClient _client;
        private readonly CookieContainer _cookieContainer;
        private readonly Uri _baseUri = new Uri("https://www.unibet.fr");

        public UnibetClient()
        {
            _cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler {CookieContainer = _cookieContainer};
            _client = new HttpClient(handler) {BaseAddress = _baseUri};
        }
        
        public async Task Login(string username, string password, string birthDate)
        {
            const string uriSuffix = "/zones/loginbox/processLogin.json";
            var queryParams = $"username={username}&password={password}&dateOfBirth={birthDate}";

            var fullUri = $"{uriSuffix}?{queryParams}";
            await Post(fullUri);
            await CheckSession();
        }

        public async Task<string> GetBetHistory()
        {
            const string uriSuffix = "/zones/myaccount/betting-history-result.json";
            const string exampleParameter =
                "datepickerFrom=13/02/2020&pageNumber=1&datepickerTo=16/02/2020&statusFilter=all&resultPerPage=10";

            var fullUri = $"{uriSuffix}?{exampleParameter}";
            return await PostJsonResult(fullUri);
        }

        private async Task CheckSession()
        {
            const string uriSuffix = "/zones/checksession.json";
            await Post(uriSuffix);
        }

        private async Task<string> PostJsonResult(string uri)
        {
            var response = await _client.PostAsync(uri, null);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task Post(string uri)
        {
            await _client.PostAsync(uri, null);
        }
    }
}
