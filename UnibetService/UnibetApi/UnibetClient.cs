using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnibetService.UnibetApi.DTO;

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

        public async Task<List<BetDto>> GetBetsHistory(DateTime dateFrom, DateTime dateTo)
        {
            var bets = new List<BetDto>();
            var pageNumber = 1;
            var hasNextPage = true;
            while (hasNextPage)
            {
                var result = await GetBetsHistoryByPage(dateFrom, dateTo, pageNumber);
                if (result.Bets != null)
                    bets.AddRange(result.Bets);
                hasNextPage = result.HasNextPage;
                pageNumber = result.CurrentPage + 1;
            }

            return bets;
        }

        private async Task<BetsHistoryDto> GetBetsHistoryByPage(DateTime dateFrom, DateTime dateTo, int pageNumber)
        {
            const string uriSuffix = "/zones/myaccount/betting-history-result.json";
            var parameters = new Dictionary<string, string>
            {
                {"datepickerFrom", dateFrom.ToString("dd/MM/yyyy")},
                {"datepickerTo", dateTo.ToString("dd/MM/yyyy")},
                {"pageNumber", pageNumber.ToString()},
                {"resultPerPage", "99"},
                {"statusFilter", "all"}
            };

            var exampleParameter = string.Join("&", parameters.Select(_ => $"{_.Key}={_.Value}"));

            var fullUri = $"{uriSuffix}?{exampleParameter}";
            var result = await PostJsonResult<BetsHistoryDto>(fullUri);
            return result;
        }

        private async Task<TDto> PostJsonResult<TDto>(string uri)
        {
            Console.WriteLine($"Send post request to: {uri}");
            var response = await _client.PostAsync(uri, null);
            return await response.Content.ReadAsAsync<TDto>();
        }

        private async Task Post(string uri)
        {
            await _client.PostAsync(uri, null);
        }
    }
}
