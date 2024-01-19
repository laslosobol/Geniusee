using System.Text.Json.Serialization;

namespace Geniusee.Library.RainfallReading;

public class RainfallReadingResponse
{
    [JsonPropertyName("items")]
    public List<RainfallReading> RainfallReadings { get; set; }
}