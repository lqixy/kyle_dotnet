using Kyle.ApiClients.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Kyle.ApiClients.Repositories.Test;

public class TestBase
{
    protected IServiceProvider Provider;

    public TestBase()
    {
        var services = new ServiceCollection();

        services.AddHttpClient();
        services.AddSingleton<IHttpApiClient, HttpApiClient>();

        Provider = services.BuildServiceProvider();
    }
}