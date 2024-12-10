using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.Tests.Defaults;

namespace RonSijm.Syringe.Tests.Base.ExamplesA;

public abstract class ResolveExamplesADefaultsBase : ResolveExamplesANoExceptionsBase
{
    protected override void ClassWithInterfaceExpectations(Func<ClassWithInterface> invocation)
    {
        invocation.NoRegistrationExpectation();
    }

    protected override void ClassWith_ClassWithInterface_AsClassExpectations(Func<ClassWith_ClassWithInterface_AsClass> invocation)
    {
        invocation.CannotResolveServiceExpectation();
    }
}