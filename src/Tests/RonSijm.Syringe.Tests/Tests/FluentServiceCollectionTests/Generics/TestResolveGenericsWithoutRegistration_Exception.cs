using RonSijm.Syringe.ExamplesB;
using RonSijm.Syringe.Tests.Base.ExamplesB;

namespace RonSijm.Syringe.Tests.Tests.FluentServiceCollectionTests.Generics;

public class TestResolveGenericsWithoutRegistration_Exception : ResolveExamplesBDefaultsBase
{
    protected override IServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        var fluent = serviceCollection.WireImplicit<ClassWith_FuncOfClass>();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }
}