using DigitalClock.Commands;
using System.ComponentModel;
using System.Globalization;

namespace DigitalClock;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly System.Timers.Timer _timer;
    private bool showSeconds;

    private DateTime _currentTime;
    private DateOnly _currentDate;
    private bool windowIsTopmost;

    public string Time => _currentTime.ToString("HH:mm");
    public string Seconds => _currentTime.ToString("ss");
    public string Date => _currentDate.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
    public string WeekDay => _currentTime.DayOfWeek.ToString();
    public bool ShowSeconds
    {
        get => showSeconds;
        set { showSeconds = value; OnPropertyChanged(nameof(ShowSeconds)); }
    }
    public bool WindowIsTopmost
    {
        get => windowIsTopmost;
        set { windowIsTopmost = value; OnPropertyChanged(nameof(WindowIsTopmost)); }
    }
    public MainViewModel()
    {
        _currentTime = DateTime.Now;
        _currentDate = DateOnly.FromDateTime(_currentTime);

        _timer = new System.Timers.Timer(TimeSpan.FromSeconds(1));
        _timer.Elapsed += OnTimer_Elapsed;

        ExitApplication = new ExitApplicationCommand();
        InvertShowSeconds = new InvertShowSecondsCommand(this);
        InvertWindowIsTopmost = new InvertWindowIsTopmostCommand(this);

        _timer.Start();
    }

    private void OnTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        DateTime nowTime = DateTime.Now;

        if (!showSeconds)
            nowTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, 0);

        if (_currentTime == nowTime) return;

        _currentTime = nowTime;
        OnPropertyChanged(nameof(Time));

        if (ShowSeconds)
            OnPropertyChanged(nameof(Seconds));

        DateOnly nowDate = DateOnly.FromDateTime(_currentTime);

        if (_currentDate == nowDate) return;

        _currentDate = nowDate;
        OnPropertyChanged(nameof(Date));
        OnPropertyChanged(nameof(WeekDay));
    }

    public ExitApplicationCommand ExitApplication { get; }
    public InvertShowSecondsCommand InvertShowSeconds { get; }
    public InvertWindowIsTopmostCommand InvertWindowIsTopmost { get; }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
