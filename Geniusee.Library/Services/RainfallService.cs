using System.ComponentModel;
using System.Text.Json;
using Geniusee.Library.RainfallReading;
using Geniusee.Library.Utils;

namespace Geniusee.Library.Services;
//https://environment.data.gov.uk/flood-monitoring/id/stations/52203/readings?_sorted&_limit=100

public class RainfallService(HttpClient httpClient) : IRainfallService
{
    public async Task<RainfallReadingResponse?> GetRainfall(string id, int count)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Station ID cannot be null or empty.", nameof(id));
        }
        
        var url = $"https://environment.data.gov.uk/flood-monitoring/id/stations/{id}/readings?_sorted&_limit={count}";

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RainfallReadingResponse>(body, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new DateTimeJsonConverter() }
            });
            return result;
        }
        catch (HttpRequestException e)
        {
            throw new InvalidOperationException("Error fetching rainfall data", e);
        }
        catch (JsonException e)
        {
            throw new InvalidOperationException("Error parsing rainfall data", e);
        }
    }
}