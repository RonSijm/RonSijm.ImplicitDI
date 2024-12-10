using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.Tests.Base.ExamplesA;
using RonSijm.Syringe.Tests.Defaults;

namespace RonSijm.Syringe.Tests.Tests.FluentServiceCollectionTests.Parameters;

public class TestWireImplicit_RegisterAsTypesOnly_ClassWithInterface : ResolveExamplesANoExceptionsBase
{
    protected override IServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new SyringeServiceCollection();

        serviceCollection.WireImplicit<Class>().RegisterAsTypesOnly([typeof(ClassWithInterface)]);
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