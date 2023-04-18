using IdentityModel.Client;
using Kyle.Identity.Application.Constructs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Kyle.Identity.Application
{
    public static class IdentityClientExtensions
    {
        public static void AddIdentityClient(this IServiceCollection services
            , Action<IdentityClientOptions> configureOptions,
            IConfiguration configuration)
        {
            // services.AddTransient<TokenCookieHelper>();
            services.AddSingleton<IIdentityClientAppService, IdentityClientAppService>();
            services.Configure(configureOptions);
            
            services.AddSingleton<IDiscoveryCache>(provier =>
            {
                var factory = provier.GetRequiredService<IHttpClientFactory>();
                return new DiscoveryCache(configuration["AuthServer:Authority"], () => factory.CreateClient(),
                    policy: new DiscoveryPolicy() { RequireHttps = false });
            });
            // services.AddSingleton<IDiscoveryCache>(provider =>
            // {
            //     var factory = provider.GetRequiredService<IHttpClientFactory>();
            //     return new DiscoveryCache();
            // });
        }
    }
}
