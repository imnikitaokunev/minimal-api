using System.Reflection;
using MinimalApi.EndpointDefinition;

namespace MinimalApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddEndpointServices(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);
        foreach (var type in types)
        {
            var endpointDefinition = (IEndpointDefinition)Activator.CreateInstance(type);
            endpointDefinition?.DefineServices(services);
        }
    }
}
