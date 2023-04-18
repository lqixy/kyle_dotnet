﻿using Kyle.EntityFrameworkExtensions.Test.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyle.EntityFrameworkExtensions.Test.DbContextes;
using Microsoft.EntityFrameworkCore;

namespace Kyle.EntityFrameworkExtensions.Test
{
    public class TestBase
    {
        protected ServiceProvider Provider;

        public TestBase()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                ;

            var services = new ServiceCollection();

            services.AddSingleton<UserInfoRepository>();
            services.AddDbContext<MallDbContextTest>(options =>
            {
                options.UseSqlServer(config["ConnectionStrings:Default"]);
            });

            services.AddSingleton<TodoRepository>();
            services.AddDbContext<TodosDbContextTest>(options =>
            {
                options.UseSqlServer(config["ConnectionStrings:Todos"]);
            });  
            
            Provider = services.BuildServiceProvider();
        }
    }
}
