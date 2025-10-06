using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication2_week5_RPSSL_GUI;

public partial class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desk)
            desk.MainWindow = new GameWindow();  // <-- bruger code-only vinduet
        base.OnFrameworkInitializationCompleted();
    }
}