using System;

namespace NDetective.Models;

public class Device : IEquatable<Device>
{
    public string Ip { get; set;}
    public string Mac {get; private set;}
    
    public string Name { get; set; }
    public string Description {get; set;}

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