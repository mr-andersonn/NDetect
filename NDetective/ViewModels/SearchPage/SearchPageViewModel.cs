using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NDetective.Models;

namespace NDetective.ViewModels;

public partial class SearchPageViewModel : ViewModelBase
{
    private readonly ScanManager _scanManager = new();

    public ObservableCollection<Device> Devices { get; } = new();
        
    [RelayCommand]
    private async Task Scan()
    {
        await _scanManager.RunArpScan();
        
        Devices.Clear();
        if (_scanManager.LastScan?.Devices is null) return;
        
        foreach (var d in _scanManager.LastScan.Devices)
            Devices.Add(d);
    }


    [RelayCommand]
    private void Save()
    {
        _scanManager.SaveLastScanDevicesToCsv();
    }
}