using Autofac;
using AutoMapper;
using System.Reflection;

namespace Kyle.Infrastructure.Mapper;

public class AutoMapperModule: Autofac. Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assemelies = Kyle.Extensions.AssemblyExtensions.GetAssemblies();
        var allTypes = assemelies
            .Where(a => !a.IsDynamic && a.GetName().Name != nameof(AutoMapper))
            .Distinct() // avoid AutoMapper.DuplicateTypeMapConfigurationException
            .SelectMany(a => a.DefinedTypes)
            .ToArray();

        var openTypes = new[] {
            typeof(IValueResolver<,,>),
            typeof(IMemberValueResolver<,,,>),
            typeof(ITypeConverter<,>),
            typeof(IValueConverter<,>),
            typeof(IMappingAction<,>)
        };
        
        foreach (var type in openTypes.SelectMany(openType => 
                     allTypes.Where(t => t.IsClass && !t.IsAbstract && ImplementsGenericInterface(t.AsType(), openType))))
        {
            builder.RegisterType(type.AsType()).InstancePerDependency();
        }

        builder.Register<IConfigurationProvider>(ctx => 
                new MapperConfiguration(cfg => 
                    cfg.AddMaps(assemelies)))
        .SingleInstance();
   
        builder.Register<IMapper>(ctx => 
            new AutoMapper.Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve))
            .InstancePerDependency();

    }
    
    private static bool ImplementsGenericInterface(Type type, Type interfaceType)
        => IsGenericType(type, interfaceType) || type.GetTypeInfo().ImplementedInterfaces.Any(@interface => IsGenericType(@interface, interfaceType));

    private static bool IsGenericType(Type type, Type genericType)
        => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;

}