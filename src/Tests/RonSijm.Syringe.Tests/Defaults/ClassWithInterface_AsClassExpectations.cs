using RonSijm.Syringe.ExamplesA;
using RonSijm.Syringe.ExamplesA.Helpers;

namespace RonSijm.Syringe.Tests.Defaults;

public static class ClassWithInterface_AsClassExpectations
{
    public static void CannotResolveServiceExpectation(this Func<ClassWith_ClassWithInterface_AsClass> invocation)
    {
        invocation.CannotResolveServiceExpectation($"{ExamplesAConstants.ExpectedNamespace}.{nameof(ClassWithInterface)}");
    }
}