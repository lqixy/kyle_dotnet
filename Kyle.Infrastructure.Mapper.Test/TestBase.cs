using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kyle.Infrastructure.Mapper.Test;

public class TestBase
{
    protected ServiceProvider Provider;
    
    public TestBase()
    {
        var service = new ServiceCollection();
        service.AddAutoMapperExt();

        // service.AddAutoMapper(typeof(ItemProfile));
        Provider = service.BuildServiceProvider(); ;
    }
}