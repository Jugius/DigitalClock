
namespace DigitalClock.Commands;

public class ExitApplicationCommand : CommandBase
{  
    public override void Execute(object? parameter)
    {
        System.Windows.Application.Current.Shutdown();
    }
}
