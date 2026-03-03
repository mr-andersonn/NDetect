using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NDetective.Models;

public class ScanManager
{
    private readonly ArpScanner _arpScanner = new();

    public ScanResult? LastScan { get; private set; }

    public async Task RunArpScan()
    {
        // Run scan
        LastScan = await _arpScanner.RunScan();
        
    }

    public void SaveLastScanDevicesToCsv()
    {
        if (LastScan is null) throw new InvalidOperationException("No scan has been run yet");

        foreach (var device in LastScan.Devices)
        {
            Console.WriteLine(device.Description);
        }
        
        
        // else add to CSV
        CsvDeviceManager.SaveDevices(LastScan.Devices);
    }

    public IEnumerable<Device> GetDevices() => CsvDeviceManager.LoadDevices();
    
    
}