using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace NDetective.Models;

public static class CsvDeviceManager
{

    private static readonly string DevicesPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Assets", "Database", "devices.csv");
    
    public static void SaveDevices(IEnumerable<Device> devices)
    {
        EnsureCsvFileExists();
        
        foreach (var d in devices)
        {
            SaveDevice(d);
        }
    }

    public static void SaveDevice(Device d)
    {
        EnsureCsvFileExists();
        if (DeviceExists(d)) return;

        var line = $"{d.Ip},{d.Mac}" + Environment.NewLine;
        File.AppendAllText(DevicesPath, line, Encoding.UTF8);
    }

    public static void DeleteDevice(Device d)
    { 
        EnsureCsvFileExists();
        if (!DeviceExists(d)) return;
        
        
    }

    private static bool DeviceExists(Device d)
    {
        if(string.IsNullOrWhiteSpace(d.Mac)) return true;

        foreach (var line in File.ReadAllLines(DevicesPath, Encoding.UTF8))
        {
            if (string.IsNullOrEmpty(line)) continue;

            var parts = line.Split(',');

            if (parts.Length == 0) continue;

            var macInFile = parts[1].Trim();

            if (string.Equals(macInFile, d.Mac.Trim(), StringComparison.OrdinalIgnoreCase)) return true;
        }

        return false;
    }

    private static void EnsureCsvFileExists()
    {
        if (File.Exists(DevicesPath)) return;
        
        Directory.CreateDirectory(Path.GetDirectoryName(DevicesPath)!);

        using var writer = new StreamWriter(DevicesPath, false, Encoding.UTF8);
        writer.WriteLine("IP, MAC");
    }

    public static IEnumerable<Device> LoadDevices()
    {
        
        var devices = new List<Device>();

        if(!File.Exists(DevicesPath)){return devices;}

        var lines = File.ReadAllLines(DevicesPath);

        if (lines.Length <= 1) return devices;

        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i];

            if (string.IsNullOrWhiteSpace(line)) continue;
            
            var parts = line.Split(',');
            
            if (parts.Length < 2) continue;

            var ip = parts[0].Trim();
            var mac = parts[1].Trim();
            
            devices.Add(new Device(ip, mac));
        }
        
        return devices;
    }
}