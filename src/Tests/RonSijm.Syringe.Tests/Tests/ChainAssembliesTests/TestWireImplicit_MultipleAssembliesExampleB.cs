using RonSijm.Syringe.Tests.Base.ExamplesB;

namespace RonSijm.Syringe.Tests.Tests.ChainAssembliesTests;

public class TestWireImplicit_MultipleAssembliesExampleB : ResolveExamplesBDefaultsBase
{
    protected override IServiceProvider SetupServiceProvider()
    {
        var serviceProvider = typeof(ExamplesA.Class).WireImplicit().WireImplicit<ExamplesB.Class>().BuildServiceProvider();

        return serviceProvider;
    }
}