using RonSijm.Syringe.ExamplesB;
using RonSijm.Syringe.ExamplesB.Helpers;
using RonSijm.Syringe.Tests.Base.ExamplesB;
using RonSijm.Syringe.Tests.Defaults;

namespace RonSijm.Syringe.Tests.Tests.FluentServiceCollectionTests.Generics;

public class TestResolveGenerics_OpenFunc : ResolveExamplesBNoExceptionsBase
{
    protected override IServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new SyringeServiceCollection();
        serviceCollection.WireImplicit<ClassWith_FuncOfClass>().AddScoped(typeof(Func<Class>), provider => new Func<Class>(provider.GetRequiredService<Class>));

        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }

    protected override void ClassWith_LazyOfClassExpectations(Func<ClassWith_LazyOfClass> invocation)
    {
        invocation.CannotResolveServiceExpectation($"System.Lazy`1[{ExamplesBConstants.ExpectedNamespace}.{nameof(Class)}]");
    }
}