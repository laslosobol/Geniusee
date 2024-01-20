using Geniusee.Library.Error;
using Geniusee.Library.RainfallReading;
using Geniusee.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Geniusee.API.Rainfall;

[ApiController]
[Route("/rainfall")]
public class RainfallController(IRainfallService rainfallService) : Controller
{
    [HttpGet("id/{stationId}/readings")]
    public async Task<IActionResult?> GetRainfall(string stationId, int count = 10)
    {
        try
        {
            var result = await rainfallService.GetRainfall(stationId, count);
            if (result == null)
            {
                return NotFound(new ErrorReading()
                {
                    Message = $"No readings found for station ID {stationId}",
                    Detail = new List<ErrorReadingDetail>()
                    {
                        new ErrorReadingDetail()
                        {
                            Message = $"No readings found for station ID {stationId}",
                            PropertyName = nameof(stationId)
                        }
                    }
                });
            }
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ErrorReading()
            {
                Message = ex.Message,
                Detail = new List<ErrorReadingDetail>()
                {
                    new ErrorReadingDetail()
                    {
                        Message = ex.Message,
                        PropertyName = ex.ParamName
                    }
                }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorReading()
            {
                Message = "An internal error occurred.",
            });
        }
    }
}