using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BetDash.Views.DashboardPage.BetsList;
using Prism.Commands;
using Prism.Navigation;
using Syncfusion.SfChart.XForms;
using UnibetClient;
using UnibetClient.DTO;
using Xamarin.Forms;

namespace BetDash.Views.DashboardPage
{
    public class DashboardPageViewModel : ViewModelBase
    {
        private Dictionary<DateTime, List<BetDto>> _betsByDay;
        private readonly IUnibetClient _unibetClient;

        private decimal? _amount;
        public decimal? Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        public DelegateCommand<object> SelectBetsCommand { get; } 

        public ObservableCollection<Color> ColorCollection { get; set; } = new ObservableCollection<Color>();

        public ObservableCollection<ChartDataPoint> ChartsValue { get; set; } = new ObservableCollection<ChartDataPoint>();

        private BetsListViewModel _selectedBets;
        public BetsListViewModel SelectedBets
        {
            get => _selectedBets;
            set => SetProperty(ref _selectedBets, value);
        }

        public DashboardPageViewModel(INavigationService navigationService, IUnibetClient client)
            : base(navigationService)
        {
            Title = "Main Page";
            _unibetClient = client;
            SelectBetsCommand = new DelegateCommand<object>(SelectBets);
        }

        private void SelectBets(object obj)
        {
            var selectedItem = ChartsValue[(int) obj];
            var selectedDate = DateTime.Parse(selectedItem.XValue.ToString());
            SelectedBets = new BetsListViewModel(_betsByDay[selectedDate]);
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            var bets = await _unibetClient.GetBetsHistory(new DateTime(2021, 01, 11), DateTime.Today.AddDays(1));
            BuildChart(bets);
        }

        private void BuildChart(List<BetDto> bet)
        {
            Amount = 0;
            _betsByDay = bet
                .GroupBy(_ => _.Date.Date)
                .OrderBy(_ => _.Key)
                .ToDictionary(group=>group.Key, group=>group.ToList());
            foreach (var groupedBet in _betsByDay)
            {
                var dailyBenefit = groupedBet.Value.Sum(_ => _.Benefit);
                Amount += dailyBenefit;
                ColorCollection.Add(dailyBenefit > 0 ? Color.Green : Color.Red);
                ChartsValue.Add(new ChartDataPoint(groupedBet.Key.ToString("dd/MM/yyyy"), (double)Amount));
            }
            RaisePropertyChanged(nameof(ChartsValue));
        }
    }
}
