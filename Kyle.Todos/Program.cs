using Autofac;
using Autofac.Extensions.DependencyInjection;
using Kyle.Common;
using Kyle.DependencyAutofac;
using Kyle.Infrastructure.ConsulFramework;
using Kyle.Infrastructure.Events;
using Kyle.Infrastructure.Mapper;
using Kyle.Infrastructure.Mediators;
using Kyle.LoggerSerilog;
using Kyle.Todos.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddSerilogLogger();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(CustomResultFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapperExt();

builder.Services.AddCommon();

builder.Services.AddAuthentication(options =>
{
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(x =>
    {
        x.AddMediator();
        x.AddEvents();
        x.RegisterType<SessionOptions>();
        builder.Services.AddAutofac(x);
    })
    ;

// // builder.Services.AddSingleton(typeof(IRepository<>));
// builder.Services.AddSingleton<ITodoAppService, TodoAppService>();
// builder.Services.AddSingleton<ITodoRepository, TodoRepository>();
//
// // builder.Services.

builder.Services.AddDbContext<TodosDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Todos"]);
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

app.MapGet("/health/check", () => Results.Ok()); ;

app.MapControllers();

app.UseConsul(builder.Configuration);

app.Run();

