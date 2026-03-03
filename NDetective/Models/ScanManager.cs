using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NDetective.Models;

public class ScanManager
{
    private readonly ArpScanner _arpScanner = new();

    private ScanResult? LastScan { get; set; }

    public async Task RunArpScan()
    {
        // Run scan
        LastScan = await _arpScanner.RunScan();
        
    }

    public void SaveLastScanDevicesToCsv()
    {
        if (LastScan is null) return;
        
        // else add to CSV
        CsvDeviceManager.SaveDevices(LastScan.Devices);
    }

    public IEnumerable<Device> GetDevice() => CsvDeviceManager.LoadDevices();
    
}