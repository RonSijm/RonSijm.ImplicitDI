using RonSijm.Syringe.Tests.Base.ExamplesA;

namespace RonSijm.Syringe.Tests.Tests.ChainAssembliesTests;

public class TestWireImplicit_MultipleAssembliesExampleA : ResolveExamplesADefaultsBase
{
    protected override IServiceProvider SetupServiceProvider()
    {
        var serviceProvider = typeof(ExamplesA.Class).WireImplicit().WireImplicit<ExamplesB.Class>().BuildServiceProvider();

        return serviceProvider;
    }
}