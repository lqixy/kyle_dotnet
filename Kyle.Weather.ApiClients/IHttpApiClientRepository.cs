using Kyle.Weather.Domain.Shared.Models;

namespace Kyle.Weather.ApiClients;

public interface IHttpApiClientRepository
{
    Task<AMapWeatherResponse> Get(string city,
        AMapWeatherExtensionsEnum aMapWeatherExtensionsEnum = AMapWeatherExtensionsEnum.Base);
}