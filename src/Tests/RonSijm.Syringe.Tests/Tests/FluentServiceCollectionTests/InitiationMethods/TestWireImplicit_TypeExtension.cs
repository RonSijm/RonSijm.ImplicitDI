using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.Tests.Base.ExamplesA;

namespace RonSijm.Syringe.Tests.Tests.FluentServiceCollectionTests.InitiationMethods;

public class TestWireImplicit_TypeExtension : ResolveExamplesADefaultsBase
{
    protected override IServiceProvider SetupServiceProvider()
    {
        var serviceProvider = typeof(Class).WireImplicit().BuildServiceProvider();

        return serviceProvider;
    }
}