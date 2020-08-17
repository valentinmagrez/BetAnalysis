using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnibetService.UnibetApi.DTO;

namespace UnibetService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<BetDto>> Get(DateTime startDate, DateTime endDate)
        {
            var service = new UnibetApi.UnibetService();
            await service.Login(Identifiant.pseudo, Identifiant.password, Identifiant.birthDate);
            var bets = await service.GetBetsHistory(startDate, endDate);
            return bets;
        }
    }
}
