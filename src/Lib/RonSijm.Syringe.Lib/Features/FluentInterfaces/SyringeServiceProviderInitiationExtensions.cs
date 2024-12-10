using System.Reflection;

namespace RonSijm.Syringe;

public static class SyringeServiceProviderInitiationExtensions
{
    public static SyringeServiceCollectionAndRegistration WireImplicit<T>(this SyringeServiceCollectionAndRegistration services)
    {
        return WireImplicit(services, typeof(T).Assembly);
    }

    public static SyringeServiceCollectionAndRegistration WireImplicit(this SyringeServiceCollectionAndRegistration services, Type typeInAssembly)
    {
        return WireImplicit(services, typeInAssembly.Assembly);
    }

    public static SyringeServiceCollectionAndRegistration WireImplicit(this SyringeServiceCollectionAndRegistration services, Assembly assembly)
    {
        return WireImplicit(services.Collection, assembly);
    }

    public static SyringeServiceCollectionAndRegistration WireImplicit<T>(this SyringeServiceCollection services)
    {
        return WireImplicit(services, typeof(T).Assembly);
    }

    public static SyringeServiceCollectionAndRegistration WireImplicit(this SyringeServiceCollection services, Type typeInAssembly)
    {
        return WireImplicit(services, typeInAssembly.Assembly);
    }

    public static SyringeServiceCollectionAndRegistration WireImplicit(this Type targetType)
    {
        var collection = new SyringeServiceCollection();
        return WireImplicit(collection, targetType);
    }

    public static SyringeServiceCollectionAndRegistration WireImplicit(this Assembly targetAssembly)
    {
        var collection = new SyringeServiceCollection();
        return WireImplicit(collection, targetAssembly);
    }

    public static SyringeServiceCollectionAndRegistration WireImplicit(this SyringeServiceCollection services, Assembly assembly)
    {
        var result = new SyringeServiceCollectionAndRegistration
        {
            Collection = services
        };

        var registration = new SyringeServiceDescriptor
        {
            Assembly = assembly
        };

        result.Descriptor = registration;

        services.Descriptors.Enqueue(registration);

        return result;
    }
}