using Geniusee.Library.RainfallReading;
using Geniusee.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Geniusee.API.Rainfall;

[ApiController]
[Route("/rainfall")]
public class RainfallController(IRainfallService rainfallService) : Controller
{
    [HttpGet("id/{stationId}/readings")]
    public async Task<RainfallReadingResponse?> GetRainfall(string stationId, int count = 10)
    {
        var result = await rainfallService.GetRainfall(stationId, count);
        return result;
    }
}