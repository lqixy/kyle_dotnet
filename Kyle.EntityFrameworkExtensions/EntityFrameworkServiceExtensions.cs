using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kyle.EntityFrameworkExtensions
{
    public static class EntityFrameworkServiceExtensions
    {
        public static void AddEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KyleDbContextBase>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:Default"]);
            });
        }

        // public static void AddEfCoreV2(this IServiceCollection services, string connectionString)
        // {
        //     services.AddDbContext<TodoDbContext>(
        //         options=> options.UseSqlServer(connectionString));
        // }
        // public static void AddEfCoreV2(this IServiceCollection services, string connectionString)
        // {
        //     services.AddDbContext<TodoDbContext>(options =>
        //     {
        //         options.UseSqlServer(connectionString);
        //     });
        // }
    }
}
