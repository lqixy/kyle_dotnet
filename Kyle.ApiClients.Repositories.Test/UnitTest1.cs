using Kyle.ApiClients.Domain;
using Kyle.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Kyle.ApiClients.Repositories.Test;

[TestClass]
public class UnitTest1 : TestBase
{
    private readonly IHttpApiClient _apiClient;

    public UnitTest1()
    {
        _apiClient = Provider.GetRequiredService<IHttpApiClient>();
    }

    [TestMethod]
    public async Task When_ApiClient_Should_OK()
    {
        var input = new AMapWeatherRequest("410100", AMapWeatherExtensionsEnum.All);
        var attribute = ApiUrlAttributeHelper.GetApiUrlAttribute<AMapWeatherRequest>();
        var url = $"https://restapi.amap.com{attribute.GetUrl()}";
        var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(input.ToJsonString());
        var uri = $"{url}?{string.Join("&", dic.Select(x => $"{x.Key}={x.Value}"))}";
        var response = await _apiClient.GetAsync<AMapWeatherResponse>(uri);
    }
}