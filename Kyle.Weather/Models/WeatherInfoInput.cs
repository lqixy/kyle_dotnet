using Kyle.Weather.Domain.Shared.Models;

namespace Kyle.Weather.Models;

/// <summary>
/// 
/// </summary>
public class WeatherInfoInput
{
    /// <summary>
    /// 城市编码
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// 气象类型 0:实况天气; 1:预报天气
    /// </summary>
    public AMapWeatherExtensionsEnum Extensions { get; set; } = AMapWeatherExtensionsEnum.Base;
}