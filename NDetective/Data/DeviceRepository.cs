using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NDetective.Models;

namespace NDetective.Data;

public class DeviceRepository
{
    
    public void Add(Device d)
    {
        using var connection = new SqliteConnection(Database.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
                              INSERT INTO Devices(Ip, Mac, Description)
                              VALUES($ip, $mac, $description);
                              """;
        command.Parameters.AddWithValue($"ip", d.Ip);
        command.Parameters.AddWithValue($"mac", d.Mac);
        command.Parameters.AddWithValue($"description", d.Description ?? string.Empty);

        command.ExecuteNonQuery();
    }

    public void AddAll(IEnumerable<Device> ds)
    {
        throw new NotImplementedException();
    }

    public Device? GetByMac(string mac)
    {
        using var connection = new SqliteConnection(Database.ConnectionString);
        connection.Open();
        
        using var command = connection.CreateCommand();
        command.CommandText = """
                              SELECT Ip, Mac, Description
                              FROM Devices
                              WHERE Mac = @mac;
                              """;
        
        command.Parameters.AddWithValue($"mac", mac);
        
        using var reader = command.ExecuteReader();
        
        if (!reader.Read()) return null;
        var foundIp = reader.GetString(0);
        var foundMac = reader.GetString(1);
        var foundDescription = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

        var device = new Device(foundIp, foundMac)
        {
            Description = foundDescription
        };
        
        return device;

    }

    public IEnumerable<Device> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Update(Device d)
    {
        using var connection = new SqliteConnection(Database.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
                              UPDATE Devices
                              SET Ip = @ip,
                                  Description = @description
                              WHERE Mac = @mac;
                              """;
        
        command.Parameters.AddWithValue($"ip", d.Ip);
        command.Parameters.AddWithValue($"mac", d.Mac);
        command.Parameters.AddWithValue($"description", d.Description ?? string.Empty);

        command.ExecuteNonQuery();
    }

    public void Delete(Device d)
    {
        using var connection = new SqliteConnection(Database.ConnectionString);
        connection.Open();
        
        using var command = connection.CreateCommand();
        command.CommandText = """
                              DELETE FROM Devices
                              WHERE Mac = @mac;
                              """;
        
        command.Parameters.AddWithValue($"mac", d.Mac);
        
        command.ExecuteNonQuery();
        
    }

}