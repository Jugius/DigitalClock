namespace DigitalClock.Commands;

public class InvertShowSecondsCommand(MainViewModel mainViewModel) : CommandBase
{
    public override void Execute(object? parameter)
    {
        mainViewModel.ShowSeconds = !mainViewModel.ShowSeconds;
        var settings = StartupSettings.GetSettings();
        if (settings.ShowSeconds != mainViewModel.ShowSeconds)
        {
            settings.ShowSeconds = mainViewModel.ShowSeconds;
            settings.Save();
        }
    }
}
