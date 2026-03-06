using Avalonia;
using System;
using System.Linq;
using System.Threading.Tasks;
using NDetective.Data;

namespace NDetective;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        Database.InitializeDatabase();
        
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
        

    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}