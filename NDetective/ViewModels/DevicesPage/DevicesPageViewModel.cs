using System.Collections.Generic;
using System.Collections.ObjectModel;
using NDetective.Models;

namespace NDetective.ViewModels;

public class DevicesPageViewModel : ViewModelBase
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
    
}