namespace ModulatorApp;

public partial class ModulatorsPage : ContentPage
{
    public ModulatorsPage()
    {
        InitializeComponent();
    }
    private async void OnModulatorClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            var medication = (btn.CommandParameter ?? btn.Text)?.ToString() ?? string.Empty;
            await Shell.Current.GoToAsync($"{nameof(TimerSetupPage)}?med={Uri.EscapeDataString(medication)}");

        }
    }
}
