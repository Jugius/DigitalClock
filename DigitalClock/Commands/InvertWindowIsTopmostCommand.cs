
namespace DigitalClock.Commands;

public class InvertWindowIsTopmostCommand(MainViewModel mainViewModel) : CommandBase
{
    public override void Execute(object? parameter)
    {
        mainViewModel.WindowIsTopmost = !mainViewModel.WindowIsTopmost;
        var settings = StartupSettings.GetSettings();
        if (settings.IsTopmost != mainViewModel.WindowIsTopmost)
        {
            settings.IsTopmost = mainViewModel.WindowIsTopmost;
            settings.Save();
        }
    }
}
