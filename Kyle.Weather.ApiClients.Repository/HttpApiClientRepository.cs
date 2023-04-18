using Kyle.ApiClients.Domain;
using Kyle.Weather.Domain.Shared.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Kyle.Weather.ApiClients.Repository;

public class HttpApiClientRepository : IHttpApiClientRepository
{
    private readonly IHttpApiClient _httpApiClient;
    private readonly IConfiguration _configuration;

    public HttpApiClientRepository(IHttpApiClient httpApiClient
        , IConfiguration configuration
    )
    {
        _httpApiClient = httpApiClient;
        _configuration = configuration;
    }

    public async Task<AMapWeatherResponse> Get(string city,
        AMapWeatherExtensionsEnum aMapWeatherExtensionsEnum = AMapWeatherExtensionsEnum.Base)
    {
        var key = _configuration["AMap:Key"];
        var urlBase = _configuration["AMap:Url"];
        var input = new AMapWeatherRequest(city, aMapWeatherExtensionsEnum, key: key);
        var attribute = ApiUrlAttributeHelper.GetApiUrlAttribute<AMapWeatherRequest>();
        var paramsDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(
            JsonConvert.SerializeObject(input));
        var parameters = string.Join("&", paramsDic.Select(x => $"{x.Key}={x.Value}"));
        var url = $"{urlBase}{attribute.GetUrl()}?{parameters}";

        var result = await _httpApiClient.GetAsync<AMapWeatherResponse>(url);
        return result;
    }
}