using System.Text.Json;
using Geniusee.Library.RainfallReading;

namespace Geniusee.Library.Services;
//https://environment.data.gov.uk/flood-monitoring/id/stations/52203/readings?_sorted&_limit=100

public class RainfallService(HttpClient httpClient) : IRainfallService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<RainfallReadingResponse?> GetRainfall(string id, int count)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Station ID cannot be null or empty.", nameof(id));
        }
        
        var url = $"https://environment.data.gov.uk/flood-monitoring/id/stations/{id}/readings?_sorted&_limit={count}";

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RainfallReadingResponse>(body);
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