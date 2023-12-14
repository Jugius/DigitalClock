using System.Text.Json;
using System.Text.Json.Serialization;

namespace DigitalClock;

internal class StartupSettings
{
    private static StartupSettings? instance;

    [JsonPropertyName("seconds")]
    public bool ShowSeconds { get; set; }


    [JsonPropertyName("top")]
    public double WindowTop { get; set; }


    [JsonPropertyName("left")]
    public double WindowLeft { get; set; }


    [JsonPropertyName("topmost")]
    public bool IsTopmost { get; set; }

    public static StartupSettings GetSettings() => instance ??= LoadOrDefault();

    [JsonConstructor]
    private StartupSettings() { }

    private static StartupSettings LoadOrDefault()
    {
        string file = "settings.cfg";
        if (System.IO.File.Exists(file))
        { 
            return JsonSerializer.Deserialize<StartupSettings>(System.IO.File.ReadAllText(file));
        }
        return new StartupSettings 
        {
            ShowSeconds = true,
            IsTopmost = true,
        };
    }
    public void Save()
    {
        string file = "settings.cfg";
        string serialized = JsonSerializer.Serialize(this);
        System.IO.File.WriteAllText(file, serialized);
    }
}
