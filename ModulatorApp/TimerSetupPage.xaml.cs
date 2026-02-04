using ModulatorApp.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ModulatorApp;

public partial class TimerSetupPage : ContentPage
{
    private readonly TimerSetupVm _vm;

    public TimerSetupPage(string medication)
    {
        InitializeComponent();
        _vm = new TimerSetupVm { Medication = medication };
        BindingContext = _vm;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        ModulatorCardStore.Cards.Add(new ModulatorCard
        {
            Medication = _vm.Medication,
            Time1 = _vm.Time1,
            Time2 = _vm.Time2Enabled ? _vm.Time2 : null
        });

        await Shell.Current.GoToAsync("//home");
    }
}

public class TimerSetupVm
{
    public string Medication { get; set; } = "";

    public TimeSpan Time1 { get; set; } = new(8, 0, 0);

    public bool Time2Enabled { get; set; } = true;

    public TimeSpan Time2 { get; set; } = new(20, 0, 0);
}
