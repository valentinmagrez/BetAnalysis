using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddBootstrapProviders()
                .AddFontAwesomeIcons()
                .AddScoped(_ => new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:49161")
                });
            var host = builder.Build();

            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();
            await host.RunAsync();
        }
    }
}
