namespace ModulatorApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("home", typeof(MainPage));
            Routing.RegisterRoute("modulatorspage", typeof(ModulatorsPage));
            Routing.RegisterRoute(nameof(TimerSetupPage), typeof(TimerSetupPage));

        }
    }
}
