
using Kyle.Common; 
using Kyle.DependencyServiceCollection;
using Kyle.Encrypt.Application;
using Kyle.Encrypt.Application.Constructs;
using Kyle.EntityFrameworkExtensions;
using Kyle.Infrastructure.CAP;
using Kyle.Infrastructure.Mapper;
using Kyle.Infrastructure.Mediators;
using Kyle.Members.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Kyle.Identity.Application;
using Kyle.Identity.Application.Constructs;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Domain;

namespace Kyle.Members.Application.Test;

public class MembersTestBase
{

    //protected IContainer Container;

    protected IServiceProvider Provider;

    public MembersTestBase()
    {
        var assemblies = Extensions.AssemblyExtensions.GetAssemblies();

        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
            ;
        var services = new ServiceCollection();

        services.AddHttpClient(); 
        services.AddLogging(); 
        services.AddCAPService(configuration);
            services.AddAutoMapperExt();
            services.AddCommon();
        services.AddServices();


        services.AddIdentityClient(options =>
        {
            options.ClientId = configuration["AuthServer:ClientId"];
            options.ClientSecret = configuration["AuthServer:ClientSecret"];
        }, configuration);


        services.AddCommon();

        services.AddDbContext<MembersDbContext>(options =>
        {
            // options.UseSqlServer(builder.Configuration["ConnectionStrings:Members"]);
            options.UseMySQL(configuration["ConnectionStrings:Members"]);
        });

        //services.AddSingleton<MembersDbContext>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddSingleton<IEncryptAppService, EncryptAppService>();
        services.AddSingleton<IIdentityClientAppService, IdentityClientAppService>();
        services.AddSingleton<IMemberAppService, MemberAppService>();

         



        Provider = services.BuildServiceProvider();
            
        //var builder = new ContainerBuilder();

        //builder.AddAutofac();
        //builder.AddMediator();
        //builder.RegisterType<LoggerFactory>().As<ILoggerFactory>().SingleInstance();

        //builder.RegisterType<LongGenerator>().As<ILongGenerator>().SingleInstance();
        //builder.RegisterType<EncryptAppService>().As<IEncryptAppService>().SingleInstance();

        //builder.Register(c=> new HttpClient()).As<HttpClient>();
        
        //builder.Register(c =>
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<MembersDbContext>();
        //    optionsBuilder.UseSqlServer(configuration["ConnectionStrings:Members"]);
        //    return optionsBuilder.Options;
        //}).InstancePerLifetimeScope();

        //builder.RegisterModule(new AutoMapperModule());
        
        //builder.RegisterType<MembersDbContext>().AsSelf()
        //    .InstancePerLifetimeScope();

        //Container = builder.Build();

    }
}