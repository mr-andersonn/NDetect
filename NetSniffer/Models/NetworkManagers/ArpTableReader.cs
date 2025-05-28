using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NetSniffer.Models.NetworkManagers;

public class ArpTableReader
{
    
    // Return a list of devices
    
    
    // Run system command
    public List<Device> GetDevicesFromCache()
    {
        string command;
        string args;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            command = "/bin/bash";
            args = "-c \"ip neigh show\"";
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            command = "arp";
            args = "-a";
        }
        else
        {
            throw new PlatformNotSupportedException("Unsupported OS");
        }
        
        var output = CommandRunner.Run(command, args);
        return ParseOutput(output);
        
    }
    

    private List<Device> ParseOutput(string output)
    {
        return null;
    }

    
    
    // Read output from OS ARP cache

    // Parse lines into Device objects
}