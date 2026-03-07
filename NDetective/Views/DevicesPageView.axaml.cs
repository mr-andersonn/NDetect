using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace NDetective.Views;

public partial class DevicesPageView : UserControl
{
    private EditDeviceWindow? _editWindow;
    public DevicesPageView()
    {
        InitializeComponent();
    }

    private void OpenEditDeviceWindow(object? sender, RoutedEventArgs e)
    {
        if (_editWindow is not null)
        {
            _editWindow.Activate();
            return;
        }

        _editWindow = new EditDeviceWindow();
        
            if (sender is Button button)
            {
                var screenPoint = button.PointToScreen(new Point(0, 0));
            
                _editWindow.Position = new PixelPoint(
                    (int) (screenPoint.X + button.Bounds.Width * 1.5),
                    (int) screenPoint.Y);
            }  
            
            _editWindow.Closed += (_, _) =>
            {
                _editWindow = null;
            };
            
            _editWindow.Show();  
            
    }
}