using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using IdentityModel.Client;
using Kyle.Common;
using Kyle.DependencyAutofac;
using Kyle.Encrypt.Application;
using Kyle.Encrypt.Application.Constructs;
using Kyle.EntityFrameworkExtensions;
using Kyle.Extensions.WebApi.Models;
using Kyle.Identity.Application;
using Kyle.Identity.Application.Constructs;
using Kyle.Infrastructure.ConsulFramework;
using Kyle.Infrastructure.Events;
using Kyle.Infrastructure.Mapper;
using Kyle.Infrastructure.Mediators;
using Kyle.LoggerSerilog;
using Kyle.Members.Application;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Domain;
using Kyle.Members.EntityFramework;
using Kyle.Members.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddIdentityClient(
    options =>
    {
        options.ClientId = builder.Configuration["AuthServer:ClientId"];
        options.ClientSecret = builder.Configuration["AuthServer:ClientSecret"];
    },builder.Configuration);
// Add services to the container.
builder.AddSerilogLogger();
builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(CustomExceptionFilter));
        options.Filters.Add(typeof(CustomResultFilter));
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = (context) =>
        {
            var ajaxResponse = new AjaxResponse(1103,
                string.Join(Environment.NewLine,
                    context.ModelState.Values
                        .SelectMany(v => 
                            v.Errors.Select(e => 
                                e.ErrorMessage)))
            );

            return new JsonResult(ajaxResponse);
        };
    })
    ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/health/check", () => Results.Ok());

app.UseConsul(builder.Configuration);

app.Run();