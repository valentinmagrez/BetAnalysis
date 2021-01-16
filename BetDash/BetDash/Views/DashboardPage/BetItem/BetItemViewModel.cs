using System;
using System.Collections.ObjectModel;
using System.Linq;
using BetDash.Views.DashboardPage.BetDetails;
using Prism.Mvvm;
using UnibetClient.DTO;

namespace BetDash.Views.DashboardPage.BetItem
{
    public class BetItemViewModel : BindableBase
    {
        private readonly BetDto _bet;

        public ObservableCollection<BetDetailsViewModel> BetDetails { get; private set; }

        public BetItemViewModel(BetDto bet)
        {
            _bet = bet;
            BetDetails = new ObservableCollection<BetDetailsViewModel>(_bet.BetsDetailsDtos.Select(_=>new BetDetailsViewModel(_)));
        }

        public DateTime Date => _bet.Date;

        public double Odd => _bet.Odd.Value;

        public decimal Stack => _bet.Stake;

        public decimal? Earn => _bet.Benefit;
    }
}