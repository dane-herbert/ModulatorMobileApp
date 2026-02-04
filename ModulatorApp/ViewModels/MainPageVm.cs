using ModulatorApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ModulatorApp;

public class MainPageVm : INotifyPropertyChanged
{
    public ObservableCollection<ModulatorCard> Cards => ModulatorCardStore.Cards;

    public bool HasNoCards => Cards.Count == 0;

    public MainPageVm()
    {
        Cards.CollectionChanged += (_, __) =>
        {
            OnPropertyChanged(nameof(HasNoCards));
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
