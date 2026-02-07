using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ModulatorApp.Services;
using Microsoft.Maui.Controls;

namespace ModulatorApp;

[QueryProperty(nameof(Medication), "med")]
public partial class TimerSetupPage : ContentPage
{
    private TimerSetupVm _vm;

    public TimerSetupPage()
    {
        InitializeComponent();
        _vm = new TimerSetupVm();
        BindingContext = _vm;
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
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

    // This property is set by Shell when navigating with a query parameter (e.g. ?med=Trikafta)
    public string Medication
    {
        set
        {
            if (_vm == null)
            {
                _vm = new TimerSetupVm();
                BindingContext = _vm;
            }

            _vm.Medication = value ?? string.Empty;
        }
    }
}

public class TimerSetupVm : INotifyPropertyChanged
{
    private string _medication = "";
    private TimeSpan _time1 = new(8, 0, 0);
    private bool _time2Enabled = true;
    private TimeSpan _time2 = new(20, 0, 0);

    public string Medication
    {
        get => _medication;
        set => SetProperty(ref _medication, value);
    }

    public TimeSpan Time1
    {
        get => _time1;
        set => SetProperty(ref _time1, value);
    }

    public bool Time2Enabled
    {
        get => _time2Enabled;
        set => SetProperty(ref _time2Enabled, value);
    }

    public TimeSpan Time2
    {
        get => _time2;
        set => SetProperty(ref _time2, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }
}
