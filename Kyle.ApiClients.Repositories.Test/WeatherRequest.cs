using Kyle.ApiClients.Domain;

namespace Kyle.ApiClients.Repositories.Test;


public class WeatherRequestBase : IApiRequest
{
    public string Key { get; set; }
}
public class WeatherRequest: WeatherRequestBase
{
    // "https://restapi.amap.com/v3/weather/weatherInfo?city=110101&key=<用户key>"
    
}