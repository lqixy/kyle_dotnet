using Kyle.Infrastructure.RedisExtensions;
using Kyle.Weather.Application.Constructs;
using Kyle.Weather.Domain.Shared.Models;
using Kyle.Weather.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kyle.Weather.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherAppService _appService;
    private readonly Lazy<IRedisCacheManager> _manager;

    public WeatherController(IWeatherAppService appService, Lazy<IRedisCacheManager> manager)
    {
        _appService = appService;
        _manager = manager;
    }

    /// <summary>
    /// 天气
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<AMapWeatherResponse> Get(WeatherInfoInput input)
    {
        var key = $"{input.City}:{input.Extensions.ToString()}:{DateTime.Now:yyyy/MM/dd}";
        var result = await _manager.Value
            .GetCache<string, AMapWeatherResponse>()
            .GetAsync(key,
                async (k) => await _appService.Get(input.City, input.Extensions));
        return result;
    }
}