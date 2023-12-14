using System.Windows;

namespace DigitalClock;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var settings = StartupSettings.GetSettings();
        var model = new MainViewModel
        {
            ShowSeconds = settings.ShowSeconds,
            WindowIsTopmost = settings.IsTopmost
        };

        this.MainWindow = new MainWindow
        {
            Top = settings.WindowTop,
            Left = settings.WindowLeft,
            DataContext = model
        };
        model.StartTimer();
        this.MainWindow.Show();
        base.OnStartup(e);
    }
}
