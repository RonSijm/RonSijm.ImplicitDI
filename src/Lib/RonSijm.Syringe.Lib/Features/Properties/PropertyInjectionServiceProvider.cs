using System.Reflection;

namespace RonSijm.Syringe;

public class PropertyInjectionServiceProvider(IServiceProvider innerProvider) : IServiceProvider
{
    public object GetService(Type serviceType)
    {
        var service = innerProvider.GetService(serviceType);
        
        if (service == null)
        {
            return null;
        }

        var properties = service.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanWrite && p.PropertyType != typeof(string) && innerProvider.GetService(p.PropertyType) != null);

        foreach (var property in properties)
        {
            property.SetValue(service, innerProvider.GetService(property.PropertyType));
        }

        return service;
    }
}