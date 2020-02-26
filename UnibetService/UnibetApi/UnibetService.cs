using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnibetService.UnibetApi.DTO;

namespace UnibetService.UnibetApi
{
    public class UnibetService
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

        public async Task<List<BetDto>> GetBetsHistoryParallel(DateTime from, DateTime to)
        {
            var tasks = new List<Task<List<BetDto>>>();
            var bets = new List<BetDto>();
            var currentDateFrom = from;
            for (var currentDateTo = from.AddMonths(1); currentDateTo <= to; currentDateFrom = currentDateTo.AddDays(1), currentDateTo = currentDateTo.AddMonths(1))
            {
                tasks.Add(_unibetClient.GetBetsHistory(currentDateFrom, currentDateTo));
            }

            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                bets.AddRange(task.Result);
            }

            return bets;
        }
    }
}
