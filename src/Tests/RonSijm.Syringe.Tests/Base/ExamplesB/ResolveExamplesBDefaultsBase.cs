using RonSijm.Syringe.ExamplesB.Helpers;
using RonSijm.Syringe.ExamplesB;
using RonSijm.Syringe.Tests.Defaults;

namespace RonSijm.Syringe.Tests.Base.ExamplesB;

public abstract class ResolveExamplesBDefaultsBase : ResolveExamplesBNoExceptionsBase
{
    protected override void ClassWith_FuncOfClassExpectations(Func<ClassWith_FuncOfClass> invocation)
    {
        invocation.CannotResolveServiceExpectation($"System.Func`1[{ExamplesBConstants.ExpectedNamespace}.{nameof(Class)}]");
    }

    protected override void ClassWith_LazyOfClassExpectations(Func<ClassWith_LazyOfClass> invocation)
    {
        invocation.CannotResolveServiceExpectation($"System.Lazy`1[{ExamplesBConstants.ExpectedNamespace}.{nameof(Class)}]");
    }
}