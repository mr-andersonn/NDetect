using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NDetective.Data;
using NDetective.Models;

namespace NDetective.ViewModels;

public partial class AddDeviceViewModel : ViewModelBase
{

    [ObservableProperty] private string _mac;
    [ObservableProperty] private string _ip;
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _description;
    
    public event Action? DeviceAdded;

    [RelayCommand]
    private void AddDevice()
    {
        Device d = new Device(Mac, Ip, Name, Description);
        
        DeviceRepository.Add(d);
        
        DeviceAdded?.Invoke();
        
    }
}