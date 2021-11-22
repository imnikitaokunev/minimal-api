using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Extensions;
using MinimalApi.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointServices(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.AddEndpointDefinitions(Assembly.GetExecutingAssembly());

app.Run();
