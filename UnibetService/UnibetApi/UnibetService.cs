using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnibetService.UnibetApi.DTO;

namespace UnibetService.UnibetApi
{
    public class UnibetService : IUnibetService
    {
        private readonly UnibetClient _unibetClient;

        public UnibetService()
        {
            _unibetClient = new UnibetClient();
        }

        public async Task Login(string username, string password, string birthDate)
        {
            await _unibetClient.Login(username, password, birthDate);
        }

        public async Task<List<BetDto>> GetBetsHistory(DateTime from, DateTime to)
        {
            var tasks = new List<Task<List<BetDto>>>();
            var bets = new List<BetDto>();
            var currentDateFrom = from;
            var currentDateTo = new DateTime();
            while (currentDateTo != to)
            {
                currentDateTo = currentDateFrom.AddMonths(1) <= to ? currentDateFrom.AddMonths(1) : to;
                tasks.Add(_unibetClient.GetBetsHistory(currentDateFrom, currentDateTo));
                currentDateFrom = currentDateTo.AddDays(1);
            }

            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                bets.AddRange(task.Result);
            }

            return bets;
        }

        public async Task<List<BetDto>> GetAllBets()
        {
            var dateTo = DateTime.Now;
            var bets = new List<BetDto>();
            var foundFirstBet = false;
            while (!foundFirstBet)
            {
                var result = await GetBetsHistory(dateTo.AddMonths(-12).AddDays(1), dateTo);
                foundFirstBet = result.Exists(_=>_.IsFirstBet);
                bets.AddRange(result);
                dateTo = dateTo.AddMonths(-12);
            }

            return bets;
        }
    }
}
