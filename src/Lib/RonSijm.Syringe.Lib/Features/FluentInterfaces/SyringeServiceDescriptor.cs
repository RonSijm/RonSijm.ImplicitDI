using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RonSijm.Syringe;

internal class SyringeServiceDescriptor
{
    public Assembly Assembly { get; init; }
    public ServiceLifetime ServiceLifetime { get; set; } = SyringeGlobalSettings.DefaultServiceLifetime;
    public List<Type> RegisterAsTypesOnly { get; set; }
    public List<Type> DontRegisterTypesWithInterfaces { get; set; }
    public List<Type> RegisterBothTypeAndInterfaces { get; set; }
}