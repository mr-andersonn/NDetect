using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NDetective.Models;

public partial class Device : ObservableObject, IEquatable<Device>
{
    public string Ip { get; set;}
    public string Mac {get; private set;}

    [ObservableProperty]
    public string name;

    [ObservableProperty]
    public string description;

    public Device(string ip, string mac, string name = "Add Device Name", string description = $"Add description")
    {
        this.Ip = ip;
        this.Mac = mac;
        this.Name = name;
        this.Description = description;
    }
    
    public override string ToString()
    {
        return $"if: {Ip}, mac: {Mac}, name: {Name}, description: {Description}";
    }
    public bool Equals(Device? other)
    {
        if (other == null) return false;
        return Mac == other.Mac;
    }
    
    public override bool Equals(object? obj) => Equals(obj as Device);
    public override int GetHashCode() => HashCode.Combine(Ip, Mac);
}