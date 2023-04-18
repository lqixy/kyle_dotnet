using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kyle.Infrastructure.IdentityServer;

public static class IdentityServerExtensions
{
    public static void AddIdentityServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.ApiName = configuration["AuthServer:ApiName"];
                options.ApiSecret = configuration["AuthServer:ApiSecret"];
                options.EnableCaching = true;
                options.SaveToken = true;
                // options.CacheKeyPrefix = "token";
                options.RequireHttpsMetadata = false;
                options.SupportedTokens = IdentityServer4.AccessTokenValidation.SupportedTokens.Both;
            })
            ;
    }
}