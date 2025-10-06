using System;             // <-- nødvendig for [STAThread]
using Avalonia;

namespace AvaloniaApplication2_week5_RPSSL_GUI;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
        => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>().UsePlatformDetect().LogToTrace();
}