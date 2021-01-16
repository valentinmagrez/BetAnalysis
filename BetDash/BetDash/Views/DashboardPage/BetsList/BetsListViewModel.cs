using System.Collections.Generic;
using System.Linq;
using BetDash.Views.DashboardPage.BetItem;
using UnibetClient.DTO;

namespace BetDash.Views.DashboardPage.BetsList
{
    public class BetsListViewModel
    {
        public List<BetItemViewModel> Bets { get; }

        public BetsListViewModel(List<BetDto> bets)
        {
            Bets = bets.Select(_ => new BetItemViewModel(_)).ToList();
        }
    }
}
