using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.Tests.Base.ExamplesA;

namespace RonSijm.Syringe.Tests.Tests.ServiceCollectionTests.Parameters;

public class TestWireImplicit_RegisterBothTypeAndInterfaces_ClassWithInterface : ResolveExamplesANoExceptionsBase
{
    protected override ServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.WireImplicit<Class>(registerBothTypeAndInterfaces: [typeof(ClassWithInterface)]);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }
}