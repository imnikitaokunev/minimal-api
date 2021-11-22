using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Persistence;

public interface IApplicationDbContext
{
    DbSet<Todo> Todos { get; set; }
    int SaveChanges();
}
