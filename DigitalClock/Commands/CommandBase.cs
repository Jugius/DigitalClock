using System.Windows.Input;

namespace DigitalClock.Commands;
public abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);
}
