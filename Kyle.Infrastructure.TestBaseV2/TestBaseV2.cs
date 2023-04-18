using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kyle.Infrastructure.TestBaseV2
{
    public class TestBaseV2
    {
        protected IServiceProvider Provider;
        public TestBaseV2()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            var services = new ServiceCollection();

            

        }
    }
}

