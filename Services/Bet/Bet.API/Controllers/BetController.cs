using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnibetClient.DTO;

namespace Bet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BetController : ControllerBase
    {

        public BetController()
        {
        }

        [HttpGet]
        public async Task<IEnumerable<BetDto>> Get(DateTime startDate, DateTime endDate)
        {
            var service = new UnibetClient.UnibetService();
            await service.Login(Identifiant.pseudo, Identifiant.password, Identifiant.birthDate);
            var bets = await service.GetBetsHistory(startDate, endDate);
            return bets;
        }
    }
}
