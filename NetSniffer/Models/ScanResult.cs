using System;
using System.Collections.Generic;

namespace NetSniffer.Models;

public class ScanResult()
{
    public int id { get; set; }
    public List<Device> devices { get; set; }
    public DateTime time { get; set; }

    public void addDevice(Device device)
    {
        devices.Add(device);
    }
}