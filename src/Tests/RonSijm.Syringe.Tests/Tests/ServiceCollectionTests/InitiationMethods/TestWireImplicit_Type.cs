using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.Tests.Base.ExamplesA;

namespace RonSijm.Syringe.Tests.Tests.ServiceCollectionTests.InitiationMethods;

public class TestWireImplicit_Type : ResolveExamplesADefaultsBase
{
    protected override ServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.WireImplicit(typeof(Class));
        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }
}