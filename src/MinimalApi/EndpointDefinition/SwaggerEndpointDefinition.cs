using Microsoft.OpenApi.Models;

namespace MinimalApi.EndpointDefinition;

public class SwaggerEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("swagger/v1/swagger.json", "MinimalApi");
            c.RoutePrefix = string.Empty;
        });
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MinimalApi", Version = "v1" });
        });
    }
}
