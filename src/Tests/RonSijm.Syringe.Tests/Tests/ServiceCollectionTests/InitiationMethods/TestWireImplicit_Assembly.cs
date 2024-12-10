using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.Tests.Base.ExamplesA;

namespace RonSijm.Syringe.Tests.Tests.ServiceCollectionTests.InitiationMethods;

public class TestWireImplicit_Assembly : ResolveExamplesADefaultsBase
{
    protected override ServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        var assembly = typeof(Class).Assembly;

        serviceCollection.WireImplicit(assembly);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }
}