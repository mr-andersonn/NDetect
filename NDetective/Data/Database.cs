using Microsoft.Data.Sqlite;

namespace NDetective.Data;

public class Database
{
    public const string ConnectionString = "Data Source=ndetective.db";
    
    public static void InitializeDatabase()
    {
        using var connection = new SqliteConnection("Data Source=ndetective.db");
        connection.Open(); 

        var command = connection.CreateCommand();

        command.CommandText = @"CREATE TABLE IF NOT EXISTS Devices (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Ip TEXT NOT NULL,
                                Mac TEXT UNIQUE,
                                Name TEXT, 
                                Description TEXT);";
        
        command.ExecuteNonQuery();
    }
}