using BetDash.Settings;
using BetDash.Views.DashboardPage;
using BetDash.Views.Login;
using Prism;
using Prism.Ioc;
using UnibetClient;

namespace BetDash
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(LicenceKey.SYNCFUSION);

            InitializeComponent();

            await NavigationService.NavigateAsync(nameof(LoginPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterNavigation(containerRegistry);
            containerRegistry.RegisterInstance<IUnibetClient>(new UnibetClient.UnibetClient());
        }

        private static void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
