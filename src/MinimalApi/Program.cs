using System.Reflection;
using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointServices(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.AddEndpointDefinitions(Assembly.GetExecutingAssembly());

app.Run();
