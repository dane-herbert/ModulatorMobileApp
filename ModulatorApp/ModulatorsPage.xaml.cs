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
            var medication = btn.Text;
            await Navigation.PushAsync(new TimerSetupPage(medication));
            // If you prefer Shell routes instead:
            // await Shell.Current.GoToAsync($"{nameof(TimerSetupPage)}?med={Uri.EscapeDataString(medication)}");
        }
    }
}
