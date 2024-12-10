using Microsoft.Extensions.DependencyInjection;

namespace RonSijm.Syringe;

public static class SyringeServiceProviderExtensions
{
    public static SyringeServiceCollectionAndRegistration WithLifetime(this SyringeServiceCollectionAndRegistration registration, ServiceLifetime config)
    {
        registration.Descriptor.ServiceLifetime = config;

        return registration;
    }

    public static SyringeServiceCollectionAndRegistration RegisterBothTypeAndInterfaces(this SyringeServiceCollectionAndRegistration registration, params IReadOnlyCollection<Type> config)
    {
        registration.Descriptor.RegisterBothTypeAndInterfaces ??= [];
        registration.Descriptor.RegisterBothTypeAndInterfaces.AddRange(config);

        return registration;
    }

    public static SyringeServiceCollectionAndRegistration DontRegisterTypesWithInterfaces(this SyringeServiceCollectionAndRegistration registration, params IReadOnlyCollection<Type> config)
    {
        registration.Descriptor.DontRegisterTypesWithInterfaces ??= [];
        registration.Descriptor.DontRegisterTypesWithInterfaces.AddRange(config);

        return registration;
    }

    public static SyringeServiceCollectionAndRegistration RegisterAsTypesOnly(this SyringeServiceCollectionAndRegistration registration, params IReadOnlyCollection<Type> config)
    {
        registration.Descriptor.RegisterAsTypesOnly ??= [];
        registration.Descriptor.RegisterAsTypesOnly.AddRange(config);

        return registration;
    }
}