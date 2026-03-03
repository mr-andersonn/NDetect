using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NDetective.Models;

namespace NDetective.ViewModels;

public partial class SearchPageViewModel : ViewModelBase
{
    private static readonly ScanManager _scanManager = new();
    public ObservableCollection<Device> Devices { get; } = new();
    public ObservableCollection<Device> SavedDevices { get; } = new(_scanManager.GetDevices());
    
    public ObservableCollection<DisplayedDevice> displayedDevices { get; } = new();
    
    [RelayCommand]
    private async Task Scan()
    {
        await _scanManager.RunArpScan();
        
        Devices.Clear();
        if (_scanManager.LastScan?.Devices is null) return;

        foreach (var d in _scanManager.LastScan.Devices)
        {
            Devices.Add(d);
            
            bool isAuthorized = SavedDevices.Contains(d);
            
            displayedDevices.Add(new DisplayedDevice(d, isAuthorized));
        }

    }
    
    [RelayCommand]
    private void Save()
    {
        _scanManager.SaveLastScanDevicesToCsv();
    }
}