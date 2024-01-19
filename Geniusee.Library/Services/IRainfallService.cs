using Geniusee.Library.RainfallReading;

namespace Geniusee.Library.Services;

public interface IRainfallService
{
    public Task<RainfallReadingResponse?> GetRainfall(string id, int count);
}