using Kyle.ApiClients.Domain;

namespace Kyle.ApiClients.Repositories.Test;

public class AMapResponseBase : IApiResponse
{
    /// <summary>
    /// 返回状态 0:失败 1:成功
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 结果总数
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 状态信息
    /// </summary>
    public string Info { get; set; }

    /// <summary>
    /// 状态说明 10000代表正确
    /// </summary>
    public string InfoCode { get; set; }
}

public class AMapWeatherResponse : AMapResponseBase
{
    public IEnumerable<AMapWeatherLiveResponse> Lives { get; set; } =
        Enumerable.Empty<AMapWeatherLiveResponse>();

    public IEnumerable<AMapWeatherForecastResponse> Forecast { get; set; } =
        Enumerable.Empty<AMapWeatherForecastResponse>();
}

/// <summary>
/// 实况天气
/// </summary>
public class AMapWeatherLiveResponse
{
    /// <summary>
    /// 省份
    /// </summary>
    public string Province { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// 区域编码
    /// </summary>
    public string Adcode { get; set; }

    /// <summary>
    /// 天气现象
    /// </summary>
    public string Weather { get; set; }

    /// <summary>
    /// 气温 摄氏度
    /// </summary>
    public int Temperature { get; set; }

    /// <summary>
    /// 风向
    /// </summary>
    public string Winddirection { get; set; }

    /// <summary>
    /// 风力
    /// </summary>
    public string WindPower { get; set; }

    /// <summary>
    /// 空气湿度
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// 数据发布的时间
    /// </summary>
    public DateTime ReportTime { get; set; }
}

public class AMapWeatherForecastResponse
{
    /// <summary>
    /// 省份
    /// </summary>
    public string Province { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// 区域编码
    /// </summary>
    public string Adcode { get; set; }

    public IEnumerable<AMapWeatherForecastCastResponse> Casts { get; set; } =
        Enumerable.Empty<AMapWeatherForecastCastResponse>();
}

public class AMapWeatherForecastCastResponse
{
    public string date { get; set; }

    public string Week { get; set; }

    public string DayWeather { get; set; }

    public string NightWeather { get; set; }

    public int DayTemp { get; set; }

    public int NightTemp { get; set; }

    public string DayWind { get; set; }

    public string NightWind { get; set; }

    public string DayPower { get; set; }

    public string NightPower { get; set; }
}