using System.Reflection;
using MinimalApi.EndpointDefinition;

namespace MinimalApi.Extensions;

public static class WebApplicationExtensions
{
    public static void AddEndpointDefinitions(this WebApplication app, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);
        foreach (var type in types)
        {
            var endpointDefinition = (IEndpointDefinition)Activator.CreateInstance(type);
            endpointDefinition?.DefineEndpoints(app);
        }
    }
}
