using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using UnibetClient;

namespace BetDash.Views.Login
{
    public class LoginPageViewModel : ViewModelBase
    {
        private IUnibetClient _unibetClient;

        public DelegateCommand LoginCommand { get; }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                SetProperty(ref _birthDate, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _connecting;
        public bool Connecting
        {
            get => _connecting;
            set => SetProperty(ref _connecting, value);
        }

        public LoginPageViewModel(INavigationService navigationService, IUnibetClient client) : base(navigationService)
        {
            Title = "Login";
            _unibetClient = client;
            LoginCommand = new DelegateCommand(async ()=> await Login(), CanLogin);
        }

        private async Task Login()
        {
            Connecting = true;
            var success = await _unibetClient.Login(Username, Password, BirthDate.ToString("dd/MM/yyyy"));
            Connecting = false;

            if (success)
                await NavigationService.NavigateAsync(nameof(MainPage));
        }

        private bool CanLogin()
        {
            return true;
        }
    }
}
