using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kyle.Infrastructure.Mapper;

public static class AutoMapperExtensions
{
    public static void AddAutoMapperExt(this IServiceCollection services)
    {
        var assemelies = Kyle.Extensions.AssemblyExtensions.GetAssemblies();
       
       services.AddAutoMapper(assemelies);
    }
}