using Microsoft.Extensions.DependencyInjection;

namespace RonSijm.Syringe;

public class SyringeServiceCollection(IServiceCollection services) : IHaveServiceCollection
{
    public IServiceCollection InnerServiceCollection { get; } = services;

    internal readonly Queue<SyringeServiceDescriptor> Descriptors = new();

    public SyringeServiceCollection() : this(new ServiceCollection())
    {
    }

    public IServiceProvider BuildServiceProvider()
    {
        // When you build the service provider, all the pending registrations get dequeued and added to the inner collection.
        // They get dequeued because you cannot modify them anymore after building.
        while (Descriptors.Count != 0)
        {
            var registration = Descriptors.Dequeue();
            InnerServiceCollection.WireImplicit(registration.Assembly, registration.ServiceLifetime, registration.RegisterAsTypesOnly, registration.DontRegisterTypesWithInterfaces, registration.RegisterBothTypeAndInterfaces);
        }

        return InnerServiceCollection.BuildServiceProvider();
    }
}