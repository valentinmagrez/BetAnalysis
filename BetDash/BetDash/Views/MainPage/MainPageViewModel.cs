﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BetDash.Settings;
using Prism.Navigation;
using Syncfusion.SfChart.XForms;
using UnibetClient.DTO;
using Xamarin.Forms;

namespace BetDash.Views.MainPage
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly UnibetClient.UnibetClient _unibetClient = new UnibetClient.UnibetClient();

        private decimal? _amount;

        public decimal? Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        public ObservableCollection<Color> ColorCollection { get; set; } = new ObservableCollection<Color>();

        public ObservableCollection<ChartDataPoint> BenefitsByDay { get; set; } = new ObservableCollection<ChartDataPoint>();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            await _unibetClient.Login(Identifiant.Username, Identifiant.Password, Identifiant.BirthDate);
            var bets = await _unibetClient.GetBetsHistory(new DateTime(2020, 12, 1), new DateTime(2020, 12, 29));
            BuildChart(bets);
        }

        private void BuildChart(List<BetDto> bets)
        {
            Amount = 0;
            var groupedBets = bets
                .GroupBy(_ => _.Date.Date)
                .OrderBy(_ => _.Key);
            foreach (var groupedBet in groupedBets)
            {
                var dailyBenefit = groupedBet.Sum(_ => _.Benefit);
                Amount += dailyBenefit;
                ColorCollection.Add(dailyBenefit > 0 ? Color.Green : Color.Red);
                BenefitsByDay.Add(new ChartDataPoint(groupedBet.Key.ToString("dd/MM/yyyy"), (double)Amount));

            }
            RaisePropertyChanged(nameof(BenefitsByDay));
        }
    }
}
