using System.Collections.ObjectModel;

namespace ModulatorApp.Services;

public class ModulatorCard
{
    public string Medication { get; set; } = "";
    public TimeSpan Time1 { get; set; }
    public TimeSpan? Time2 { get; set; } // null for once-daily
}

public static class ModulatorCardStore
{
    // Anything you add here will show on the MainPage.
    public static ObservableCollection<ModulatorCard> Cards { get; } = new();
}
