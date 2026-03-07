using CommunityToolkit.Mvvm.ComponentModel;

namespace NDetective.ViewModels;

public class EditDeviceViewModel : ViewModelBase
{
    public object SelectedDeviceMac { get; }
    public object SelectedDeviceIp { get; }
    public object WindowTitle { get; }
}