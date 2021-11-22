using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Todo> Todos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
