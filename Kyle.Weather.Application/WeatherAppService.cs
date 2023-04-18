using Kyle.Weather.ApiClients;
using Kyle.Weather.Application.Constructs;
using Kyle.Weather.Domain.Shared.Models;

namespace Kyle.Weather.Application;

public class WeatherAppService : IWeatherAppService
{
    private readonly IHttpApiClientRepository _repository;

    public WeatherAppService(IHttpApiClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<AMapWeatherResponse> Get(string city,
        AMapWeatherExtensionsEnum aMapWeatherExtensionsEnum = AMapWeatherExtensionsEnum.Base)
    {
        return await _repository.Get(city,aMapWeatherExtensionsEnum);
    }
}