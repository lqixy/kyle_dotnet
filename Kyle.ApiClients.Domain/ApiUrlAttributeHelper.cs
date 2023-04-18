namespace Kyle.ApiClients.Domain;

public class ApiUrlAttributeHelper
{
    private static readonly Dictionary<string, ApiUrlAttribute> _apiUrlGetters;

    static ApiUrlAttributeHelper()
    {
        _apiUrlGetters = new Dictionary<string, ApiUrlAttribute>();
    }

    // private static string GetMethodKey()

    public static ApiUrlAttribute GetApiUrlAttribute<TModel>() where TModel : IApiRequest
    {
        ApiUrlAttribute methodApiUrl = null;
        if (methodApiUrl == null)
        {
            methodApiUrl = typeof(TModel).GetCustomAttributes(typeof(ApiUrlAttribute), true)
                .FirstOrDefault() as ApiUrlAttribute;
            if (methodApiUrl != null && string.IsNullOrWhiteSpace(methodApiUrl.Controller))
            {
                methodApiUrl = null;
            }
        }

        if (methodApiUrl == null)
        {
            methodApiUrl = typeof(TModel).GetCustomAttributes(typeof(ApiUrlAttribute), true)
                .FirstOrDefault() as ApiUrlAttribute;
        }

        return GetAppUrl<TModel>(methodApiUrl);
    }

    protected static ApiUrlAttribute GetAppUrl<TModel>(ApiUrlAttribute apiUrlAttribute = null)
        where TModel : IApiRequest
    {
        string controller;

        if (apiUrlAttribute == null || string.IsNullOrWhiteSpace(apiUrlAttribute.Action))
        {
            return new ApiUrlAttribute();
        }

        if (!string.IsNullOrWhiteSpace(apiUrlAttribute.Controller)
            && !string.IsNullOrWhiteSpace(apiUrlAttribute.Action))
        {
            controller = apiUrlAttribute.Controller;
        }

        return apiUrlAttribute;
    }
}