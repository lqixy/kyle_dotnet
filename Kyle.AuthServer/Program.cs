using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityModel.Client;
using Kyle.AuthServer;
using Kyle.Common;
using Kyle.DependencyAutofac;
using Kyle.Encrypt.Application;
using Kyle.Encrypt.Application.Constructs;
using Kyle.Identity.Application;
using Kyle.Identity.Application.Constructs;
using Kyle.Infrastructure.ConsulFramework;
using Kyle.Infrastructure.Events;
using Kyle.Infrastructure.Mapper;
using Kyle.Infrastructure.Mediators;
using Kyle.Members.Application;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Domain;
using Kyle.Members.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//
// builder.Services.AddDbContext<MallDbContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
// });
// builder.Services.AddSingleton<MallDbContext>();
// builder.Services.AddMediator() ;

//builder.Services.AddSingleton<IIdentityUserPasswordValidatorFactory, IdentityUserPasswordValidatorFactory>()
//    .AddTransient<MallUserPasswordValidator>()
    //.AddTransient<BackendUserPasswordValidator>()
    // .AddSingleton<IEventBus,EventBus>() 
    // .AddSingleton<IResourceOwnerPasswordValidator,ResourceOwnerPasswordValidator>()
    //;


builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(builder.Configuration.GetSection("IdentityServer:ApiScopes"))
    .AddInMemoryApiResources(builder.Configuration.GetSection("IdentityServer:ApiResources"))
    .AddInMemoryClients(builder.Configuration.GetSection("IdentityServer:Clients"))
    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
    .AddProfileService<ProfileService>()
    ;
builder.Services.AddAutoMapperExt();
builder.Services.AddCommon();


builder.Services.AddDbContext<MembersDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration["ConnectionStrings:Members"]);
    options.UseMySQL(builder.Configuration["ConnectionStrings:Members"]);
});

//builder.Services.AddSingleton<MembersDbContext>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddSingleton<IEncryptAppService, EncryptAppService>();
builder.Services.AddSingleton<IIdentityClientAppService, IdentityClientAppService>();
builder.Services.AddScoped<IMemberAppService, MemberAppService>();
//builder.Services.AddTransient(typeof(IRepository<>));


builder.Services.AddSingleton<IDiscoveryCache>(provider =>
{
    var factory = provider.GetRequiredService<IHttpClientFactory>();
    return new DiscoveryCache(builder.Configuration["AuthServer:Authority"], () => factory.CreateClient(),
        policy: new DiscoveryPolicy
        {
            RequireHttps = false
        });
});


//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
//    .ConfigureContainer<ContainerBuilder>(b =>
//    {  
//        b.AddEvents();
//        b.AddMediator();
//        b.Register(c =>
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<MembersDbContext>();
//            optionsBuilder.UseMySQL(builder.Configuration.GetConnectionString("Members"));
//            // optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
//            return optionsBuilder.Options;
//        });

//        b.RegisterType<MembersDbContext>().AsSelf()
//            .InstancePerLifetimeScope();
//        b.AddAutofac();
//    })
//    ;

var app = builder.Build();

app.UseIdentityServer();

app.MapGet("/health/check", () => Results.Ok());

app.UseConsul(builder.Configuration);

app.Run();