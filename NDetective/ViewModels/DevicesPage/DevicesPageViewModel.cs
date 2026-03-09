using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NDetective.Data;
using NDetective.Models;
using NDetective.Views;

namespace NDetective.ViewModels;

public partial class DevicesPageViewModel : ViewModelBase
{
    private readonly ScanManager _scanManager = new();
    public ObservableCollection<Device> Devices { get; } = new();
    
    public DevicesPageViewModel()
    {
        LoadDevices();
        
    }

    private void LoadDevices()
    {
        Devices.Clear();
        
        foreach(var d in DeviceRepository.GetAll()) 
        {
            Devices.Add(d);
        }
        
        Console.WriteLine("LoadDevices done");
    }
    
    [ObservableProperty] private bool _isEditWindowOpen;

    public EditDeviceViewModel? CurrentEditVm { get; private set; }
    
    [RelayCommand]
    private void EditDevice(Device d)
    {
        IsEditWindowOpen = true;

        var vm = new EditDeviceViewModel(d);
        vm.DeviceDeleted += LoadDevices;

        CurrentEditVm = vm;
        OnPropertyChanged(nameof(CurrentEditVm));

    }

    
}