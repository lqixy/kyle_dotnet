using Autofac;
using Autofac.Extensions.DependencyInjection;
using Kyle.ApiClients.Domain;
using Kyle.ApiClients.Repositories;
using Kyle.DependencyAutofac;
using Kyle.Infrastructure.ConsulFramework;
using Kyle.Infrastructure.IdentityServer;
using Kyle.Infrastructure.RedisExtensions;
using Kyle.LoggerSerilog;
using Kyle.Weather.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(typeof(CustomResultFilter)); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference()
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
        Name = "Authorization", //jwt默认的参数名称
        In = ParameterLocation.Header, //jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey
    });
});

builder.Services.AddIdentityServerServices(builder.Configuration);

builder.AddSerilogLogger();

builder.Services.AddDistributedMemoryCache();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(container =>
    {
        container.RegisterType<HttpApiClient>()
            .As<IHttpApiClient>()
            .InstancePerLifetimeScope();
        builder.Services.AddAutofac(container);
    })
    ;

builder.Services.AddRedisService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/health/check", () => Results.Ok());

app.UseConsul(builder.Configuration);

app.Run();