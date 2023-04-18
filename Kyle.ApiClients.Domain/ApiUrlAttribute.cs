namespace Kyle.ApiClients.Domain;

public class ApiUrlAttribute : Attribute
{
    public ApiUrlAttribute(string areas, string controller, string action)
    {
        Areas = areas;
        Controller = controller;
        Action = action;
    }

    public ApiUrlAttribute()
    {
    }

    // public static ApiUrlAttribute GetDefaultApiUrlAttribute()
    // {
    //     return new ApiUrlAttribute("", "", "");
    // }

    public string Areas { get; set; } = "";
    public string Controller { get; set; } = "";
    public string Action { get; set; } = "";


    public string GetUrl()
    {
        return $"/{Areas}/{Controller}/{Action}".Replace("//", "/");
    }
}