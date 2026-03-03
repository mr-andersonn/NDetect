using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace NDetective.ViewModels;

public class ListItemTemplate
{
    public ListItemTemplate(Type type, string iconKey)
    {
        ModelType = type;
        Label = type.Name.Replace("PageViewModel", "");

        Application.Current!.TryFindResource(iconKey, out var res);
        ListItemIcon = (StreamGeometry)res!;
    }
        
    public string Label { get; }
    public Type ModelType { get; }
    
    public StreamGeometry ListItemIcon { get; }
}