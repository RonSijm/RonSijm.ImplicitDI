using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RonSijm.Syringe;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection WireEntryImplicit(this IServiceCollection services, ServiceLifetime defaultLifetime = ServiceLifetime.Transient,
        IReadOnlyCollection<Type> registerAsTypesOnly = null,
        IReadOnlyCollection<Type> dontRegisterTypesWithInterfaces = null,
        IReadOnlyCollection<Type> registerBothTypeAndInterfaces = null)
    {
        var assembly = Assembly.GetEntryAssembly();
        return WireImplicit(services, assembly, defaultLifetime, registerAsTypesOnly, dontRegisterTypesWithInterfaces, registerBothTypeAndInterfaces);
    }

    public static IServiceCollection WireImplicit<T>(this IServiceCollection services, ServiceLifetime defaultLifetime = ServiceLifetime.Transient,
        IReadOnlyCollection<Type> registerAsTypesOnly = null,
        IReadOnlyCollection<Type> dontRegisterTypesWithInterfaces = null,
        IReadOnlyCollection<Type> registerBothTypeAndInterfaces = null)
    {
        return WireImplicit(services, typeof(T).Assembly, defaultLifetime, registerAsTypesOnly, dontRegisterTypesWithInterfaces, registerBothTypeAndInterfaces);
    }

    public static IServiceCollection WireImplicit(this IServiceCollection services, Type targetType, ServiceLifetime defaultLifetime = ServiceLifetime.Transient,
        IReadOnlyCollection<Type> registerAsTypesOnly = null,
        IReadOnlyCollection<Type> dontRegisterTypesWithInterfaces = null,
        IReadOnlyCollection<Type> registerBothTypeAndInterfaces = null)
    {
        return WireImplicit(services, targetType.Assembly, defaultLifetime, registerAsTypesOnly, dontRegisterTypesWithInterfaces, registerBothTypeAndInterfaces);
    }

    public static IServiceCollection WireImplicit(this IServiceCollection services, Assembly targetAssembly, ServiceLifetime defaultLifetime = ServiceLifetime.Transient,
        IReadOnlyCollection<Type> registerAsTypesOnly = null,
        IReadOnlyCollection<Type> dontRegisterTypesWithInterfaces = null,
        IReadOnlyCollection<Type> registerBothTypeAndInterfaces = null)
    {
        var types = targetAssembly.GetTypes().Where(x => !x.IsAbstract).ToList();

        foreach (var type in types)
        {
            if (type.IsGenericType)
            {
                services.Add(new ServiceDescriptor(type.GetGenericTypeDefinition(), type.GetGenericTypeDefinition(), defaultLifetime));
            }
            else
            {
                var attribute = type.GetCustomAttribute<Lifetime.ServiceLifetimeAttribute>();
                var lifetime = attribute?.ServiceLifetime ?? defaultLifetime;
                var interfaces = type.GetInterfaces();

                bool registerInterfaceType;
                var registerAsType = registerBothTypeAndInterfaces != null && registerBothTypeAndInterfaces.Any(type.IsAssignableTo);

                if (registerAsType)
                {
                    registerInterfaceType = true;
                }
                else
                {
                    registerAsType = interfaces.Length == 0 || (registerAsTypesOnly != null && registerAsTypesOnly.Any(type.IsAssignableFrom));
                    registerInterfaceType = !registerAsType;
                }

                if (registerAsType)
                {
                    services.Add(new ServiceDescriptor(type, type, lifetime));
                }

                if (registerInterfaceType)
                {
                    foreach (var typeInterface in interfaces)
                    {
                        if (dontRegisterTypesWithInterfaces != null && dontRegisterTypesWithInterfaces.Any(typeInterface.IsAssignableFrom))
                        {
                            continue;
                        }

                        services.Add(new ServiceDescriptor(typeInterface, type, lifetime));
                    }
                }
            }
        }

        return services;
    }
}
