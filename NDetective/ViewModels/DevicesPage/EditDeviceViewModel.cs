using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NDetective.Models;

namespace NDetective.ViewModels;

public partial class EditDeviceViewModel : ViewModelBase
{

    [ObservableProperty] private Device _selectedDevice;

    [ObservableProperty] private string _windowTitle;

    private string Name;
    
    private string Description;
    

    public EditDeviceViewModel(Device device)
    {
        SelectedDevice = device;
        
        WindowTitle = $"Editing device: {SelectedDevice.Name}";
    }


    [RelayCommand]
    public void UpdateDevice()
    {
        
    }
}