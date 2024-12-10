using RonSijm.Syringe.ExamplesB;
using RonSijm.Syringe.ExamplesB.Helpers;
using RonSijm.Syringe.Tests.Base.ExamplesB;
using RonSijm.Syringe.Tests.Defaults;

namespace RonSijm.Syringe.Tests.Tests.FluentServiceCollectionTests.Generics;

public class TestResolveGenerics_OpenLazy : ResolveExamplesBNoExceptionsBase
{
    protected override IServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new SyringeServiceCollection();

        serviceCollection.WireImplicit<ClassWith_FuncOfClass>();
        serviceCollection.AddScoped(typeof(Lazy<>), typeof(Lazy<>));

        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }

    protected override void ClassWith_FuncOfClassExpectations(Func<ClassWith_FuncOfClass> invocation)
    {
        invocation.CannotResolveServiceExpectation($"System.Func`1[{ExamplesBConstants.ExpectedNamespace}.{nameof(Class)}]");
    }
}