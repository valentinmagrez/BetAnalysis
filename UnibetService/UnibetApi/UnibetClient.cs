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
        }

        public async Task CheckSession()
        {
            const string uriSuffix = "/zones/checksession.json";
            _cookieContainer.Add(_baseUri, new Cookie("CookieName", "cookie_value"));
            await Post(uriSuffix);
        }

        private async Task Post(string uri)
        {
            await _client.PostAsync(uri, null);
        }

        private void DisplayCookie()
        {
            foreach (Cookie cookie in _cookieContainer.GetCookies(_baseUri))
            {
                Console.WriteLine(cookie.Name +": "+cookie.Value);
            }
        }
    }
}
