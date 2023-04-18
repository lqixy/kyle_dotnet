using Kyle.Gateway;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);


//var authService = builder.Services.AddAuthentication();

//var authServerConfig = builder.Configuration.GetSection(nameof(AuthServerConfig)).Get<AuthServerConfig>();

//if(authServerConfig is not null && authServerConfig.Resources is not null)
//{
//    foreach (var resource in authServerConfig.Resources)
//    {
//        authService.AddIdentityServerAuthentication(resource.SchemeKey, options =>
//        {
//            options.Authority = authServerConfig.Authority;
//            options.ApiSecret = authServerConfig.ApiSecret;
//            options.RequireHttpsMetadata = false;
//            options.ApiName = resource.ApiName;
//            options.SupportedTokens = IdentityServer4.AccessTokenValidation.SupportedTokens.Both;
//        });
//    }
//}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = builder.Configuration["AuthServer:Authority"];
        options.ApiName = builder.Configuration["AuthServer:ApiName"];
        options.ApiSecret = builder.Configuration["AuthServer:ApiSecret"];
        options.RequireHttpsMetadata = false;
        options.SupportedTokens = IdentityServer4.AccessTokenValidation.SupportedTokens.Both;
    })

;


builder.Services.AddOcelot()
    .AddConsul()
    ;

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseOcelot();

app.Run();
