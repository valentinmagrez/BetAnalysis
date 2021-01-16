using Prism.Mvvm;
using UnibetClient.DTO;

namespace BetDash.Views.DashboardPage.BetDetails
{
    public class BetDetailsViewModel : BindableBase
    {
        private readonly BetDetailsDto _details;

        public BetDetailsViewModel(BetDetailsDto details)
        {
            _details = details;
        }

        public string EventName => _details.EventName;

        public string Selection => _details.Selection;

        public string Name => _details.Name;

        public string Sport => _details.Sport;

        public bool? IsWinning => _details.IsWinning;
    }
}
