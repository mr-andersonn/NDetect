using System;
using Avalonia.Controls.Selection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NDetective.Data;
using NDetective.Models;

namespace NDetective.ViewModels;

public partial class EditDeviceViewModel : ViewModelBase
{

    [ObservableProperty] private Device _selectedDevice;
    [ObservableProperty] private string _deviceName;
    [ObservableProperty] private string _deviceDescription;
    [ObservableProperty] private string _windowTitle;
    
    public event Action? RequestClose;
    public event Action? DeviceDeleted;
    

    public EditDeviceViewModel(Device device)
    {
        SelectedDevice = device;

        DeviceName = SelectedDevice.Name;

        DeviceDescription = SelectedDevice.Description;
        
        WindowTitle = $"Editing device: {DeviceName}";
    }

    [RelayCommand]
    public void UpdateDevice()
    {
        SelectedDevice.Name = DeviceName;
        SelectedDevice.Description = DeviceDescription;
        
        DeviceRepository.Update(SelectedDevice);
        RequestClose?.Invoke();
    }

    [RelayCommand]
    public void DeleteDevice()
    {
        DeviceRepository.Delete(SelectedDevice);
        DeviceDeleted?.Invoke();
        RequestClose?.Invoke();
    }
}