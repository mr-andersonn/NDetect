using Avalonia.Media;
using NDetective.Models;

namespace NDetective.ViewModels;

public class DisplayedDevice
{
    public Device Device { get; set; }
    
    public bool IsAuthorized { get; set; }
    
    public IBrush Foreground => IsAuthorized ? Brushes.Green : Brushes.Red;

    public DisplayedDevice(Device device, bool isAuthorized)
    {
        Device = device;
        IsAuthorized = isAuthorized;
    }
    
}