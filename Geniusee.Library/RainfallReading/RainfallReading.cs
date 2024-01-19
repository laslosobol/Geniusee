using System.Text.Json.Serialization;

namespace Geniusee.Library.RainfallReading;

public class RainfallReading
{
    [JsonPropertyName("dateTime")]
    public DateTime DateMeasured { get; set; }
    [JsonPropertyName("value")]
    public decimal AmountMeasured { get; set; }
}