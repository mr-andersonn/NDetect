using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NDetective.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _mainTextBlock = "Button is not clicked";
    private int counter = 0;
    [RelayCommand]
    public void MainButtonClicked()
    {
        MainTextBlock = "Button clicked " + ++counter + " times";
    }

    [ObservableProperty]
    private bool _isPaneOpen = true;

    [RelayCommand]
    private void HideOpenMenu()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}

