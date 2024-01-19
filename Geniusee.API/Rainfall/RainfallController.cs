using Geniusee.Library.RainfallReading;
using Geniusee.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Geniusee.API.Rainfall;

[ApiController]
[Route("/rainfall")]
public class RainfallController : Controller
{
    private readonly IRainfallService _rainfallService;

    public RainfallController(IRainfallService rainfallService)
    {
        _rainfallService = rainfallService;
    }

    [HttpGet("id/{stationId}/readings")]
    public async Task<RainfallReading> GetRainfall(string stationId, int count = 10)
    {
        return new RainfallReading();
    }
}