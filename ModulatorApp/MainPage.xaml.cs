using ModulatorApp.Services;

namespace ModulatorApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageVm();
    }

    private async void OnAddModulatorClicked(object sender, EventArgs e)
    {
        // Navigate to your modulators page or timer setup flow
        await Shell.Current.GoToAsync("//modulators");
    }
}

//public class MainPageVm
//{
//    public System.Collections.ObjectModel.ObservableCollection<ModulatorCard> Cards
//        => ModulatorCardStore.Cards;
//}
