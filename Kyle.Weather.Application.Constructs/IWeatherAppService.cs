using Kyle.Weather.Domain.Shared.Models;

namespace Kyle.Weather.Application.Constructs;

public interface IWeatherAppService
{
    Task<AMapWeatherResponse> Get(string city,
        AMapWeatherExtensionsEnum aMapWeatherExtensionsEnum = AMapWeatherExtensionsEnum.Base);
}