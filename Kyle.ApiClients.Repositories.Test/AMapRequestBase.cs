using Kyle.ApiClients.Domain;
using Newtonsoft.Json;

namespace Kyle.ApiClients.Repositories.Test;

public class AMapRequestBase : IApiRequest
{
    [JsonProperty("key")] public string Key { get; set; } = "7d90ca4c70ad19fba2e3e20f7ab15b90";
}

[ApiUrl("v3", "weather", "weatherInfo")]
public class AMapWeatherRequest : AMapRequestBase
{
    public AMapWeatherRequest(string city, AMapWeatherExtensionsEnum extensions = AMapWeatherExtensionsEnum.Base)
    {
        City = city;
        Extensions = extensions.ToString().ToLower();
    }

    /// <summary>
    /// 城市编码
    /// </summary>
    [JsonProperty("city")]
    public string City { get; set; }

    /// <summary>
    /// base:返回实况天气 all:返回预报天气
    /// </summary>
    [JsonProperty("extensions")]
    public string Extensions { get; set; }
}

public enum AMapWeatherExtensionsEnum
{
    Base,
    All
}