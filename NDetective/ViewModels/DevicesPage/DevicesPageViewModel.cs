using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NDetective.Models;

namespace NDetective.ViewModels;

public partial class DevicesPageViewModel : ViewModelBase
{
    private readonly ScanManager _scanManager = new();
    public ObservableCollection<Device> Devices { get; } = new();
    
    public DevicesPageViewModel()
    {
        foreach(var d in _scanManager.GetDevices()) 
        {
            Devices.Add(d);
        }
    }
    
    [ObservableProperty] private bool _isEditWindowOpen;

    [RelayCommand]
    private void EditDevice(Device d)
    {
        IsEditWindowOpen = true;
    }
    
}