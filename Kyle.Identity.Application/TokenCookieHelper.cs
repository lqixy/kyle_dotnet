using Kyle.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Kyle.Identity.Application;

public class TokenCookieHelper //: ITransientDependency
{
    private readonly SessionOptions _options;
    
    public TokenCookieHelper(SessionOptions options)
    {
        _options = options;
    }

    public void Write(HttpContext context, string token, string name = "mall_token")
    {
        var cookieOptions = _options.Cookie.Build(context);
        cookieOptions.Expires = string.IsNullOrWhiteSpace(token)
            ? DateTimeOffset.Now.AddYears(-1)
            : DateTimeOffset.Now.AddYears(1);
        cookieOptions.SameSite = _options.Cookie.SameSite;
        cookieOptions.Domain = _options.Cookie.Domain;
        cookieOptions.HttpOnly = _options.Cookie.HttpOnly;
        cookieOptions.IsEssential = _options.Cookie.IsEssential;
        cookieOptions.Secure = _options.Cookie.SecurePolicy != CookieSecurePolicy.None;

        var response = context.Response;
        response.Cookies.Append(name, token, cookieOptions);
    }

    public static string Read(HttpContext context, string name = "mall_token")
    {
        return context.Request.Query[name].FirstOrDefault() ??
               context.Request.Headers[name].FirstOrDefault() ?? context.Request.Cookies[name];
    }
}