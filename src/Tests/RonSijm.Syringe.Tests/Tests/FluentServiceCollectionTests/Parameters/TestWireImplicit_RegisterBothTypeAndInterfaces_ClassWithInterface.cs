using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.Tests.Base.ExamplesA;

namespace RonSijm.Syringe.Tests.Tests.FluentServiceCollectionTests.Parameters;

public class TestWireImplicit_RegisterBothTypeAndInterfaces_ClassWithInterface : ResolveExamplesANoExceptionsBase
{
    protected override IServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new SyringeServiceCollection();

        serviceCollection.WireImplicit<Class>().RegisterBothTypeAndInterfaces([typeof(ClassWithInterface)]);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }
}