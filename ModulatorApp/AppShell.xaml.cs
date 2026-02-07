using System.Diagnostics;

namespace ModulatorApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TimerSetupPage), typeof(TimerSetupPage));

            Navigating += OnShellNavigating;
        }

        private async void OnShellNavigating(object? sender, ShellNavigatingEventArgs e)
        {
            if (e.Target.Location.OriginalString.EndsWith("TimerSetupPage", StringComparison.OrdinalIgnoreCase))
            {
                await Shell.Current.GoToAsync("//modulators");
            }
        }
    }
}
