using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnibetService.UnibetApi
{
    public class UnibetClient
    {
        private readonly HttpClient _client;
        private readonly Uri _baseUri = new Uri("https://www.unibet.fr");

        public UnibetClient()
        {
            var handler = new HttpClientHandler {CookieContainer = new CookieContainer() };
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

        private async Task CheckSession()
        {
            const string uriSuffix = "/zones/checksession.json";
            await Post(uriSuffix);
        }

        public async Task<string> GetBetHistory(DateTime from, DateTime to)
        {
            const string uriSuffix = "/zones/myaccount/betting-history-result.json";
            var parameters = new Dictionary<string, string>
            {
                {"datepickerFrom", from.ToString("dd/MM/yyyy")},
                {"datepickerTo", to.ToString("dd/MM/yyyy")},
                {"pageNumber", "1"},
                {"resultPerPage", "10"},
                {"statusFilter", "all"}
            };
            var exampleParameter = string.Join("&",parameters.Select(_ => $"{_.Key}={_.Value}"));

            var fullUri = $"{uriSuffix}?{exampleParameter}";
            return await PostJsonResult(fullUri);
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
