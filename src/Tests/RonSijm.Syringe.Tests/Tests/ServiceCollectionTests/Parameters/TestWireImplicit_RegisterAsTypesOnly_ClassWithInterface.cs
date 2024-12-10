using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.Tests.Base.ExamplesA;
using RonSijm.Syringe.Tests.Defaults;

namespace RonSijm.Syringe.Tests.Tests.ServiceCollectionTests.Parameters;

public class TestWireImplicit_RegisterAsTypesOnly_ClassWithInterface : ResolveExamplesANoExceptionsBase
{
    protected override ServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.WireImplicit<Class>(registerAsTypesOnly: [typeof(ClassWithInterface)]);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }

    protected override void ClassWith_ClassWithInterface_AsInterfaceExpectations(Func<ClassWith_ClassWithInterface_AsInterface> invocation)
    {
        invocation.CannotResolveServiceExpectation();
    }

    protected override void InterfaceFor_ClassWithInterfaceExpectations(Func<InterfaceFor_ClassWithInterface> invocation)
    {
        invocation.NoRegistrationExpectation();
    }
}