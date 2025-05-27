using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace NetSniffer.Models.NetworkManagers;

/*
 * Responsibilities
 *
 * 1. Get Local IP
 * 2. Get Subnet mask
 * 3. Calculate subnet range
 * 
 */

public class NetworkInfoProvider
{
    public readonly IPAddress Ip;
    public readonly IPAddress SubnetMask;
    public record struct IpRange(IPAddress Start, IPAddress End);
    public readonly IpRange SubnetRange;
    
    private readonly UnicastIPAddressInformation _unicast;

    public NetworkInfoProvider()
    {
        _unicast = GetUnicast() ?? throw new Exception("No active IPv4 network interface found");
        
        Ip = GetLocalIp();
        SubnetMask = GetSubnetMask();
        
        SubnetRange = CalculateSubnetRange();
    }

    private IPAddress GetLocalIp()
    {
        return _unicast.Address;
    }

    private IPAddress GetSubnetMask()
    {
        return _unicast.IPv4Mask;
    }

    private IpRange CalculateSubnetRange()
    {
        
        
        return null;
    }

    private UnicastIPAddressInformation? GetUnicast()
    {
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

        NetworkInterface? active = interfaces.FirstOrDefault(n =>
            n.OperationalStatus == OperationalStatus.Up &&
            n.NetworkInterfaceType != NetworkInterfaceType.Loopback);

        if (active == null)
            return null;
        
        return active.GetIPProperties()
                .UnicastAddresses
                .FirstOrDefault(u => u.Address.AddressFamily == AddressFamily.InterNetwork);


    }
}
