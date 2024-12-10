namespace RonSijm.Syringe.Tests.Defaults;

public static class CannotResolveServiceExpectations
{
    public static void CannotResolveServiceExpectation<T>(this Func<T> invocation, string source)
    {
        invocation.Should().Throw<InvalidOperationException>().WithMessage($"Unable to resolve service for type '{source}' while attempting to activate '{typeof(T).FullName}'.");
    }
}