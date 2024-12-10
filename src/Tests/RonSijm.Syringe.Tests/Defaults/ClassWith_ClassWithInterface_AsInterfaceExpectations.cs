using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.ExamplesA.Helpers;

namespace RonSijm.Syringe.Tests.Defaults;

public static class ClassWith_ClassWithInterface_AsInterfaceExpectations
{
    public static void CannotResolveServiceExpectation(this Func<ClassWith_ClassWithInterface_AsInterface> invocation)
    {
        invocation.CannotResolveServiceExpectation($"{ExamplesAConstants.ExpectedNamespace}.{nameof(InterfaceFor_ClassWithInterface)}");
    }
}