using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Persistence;

internal class TodoRepository : ITodoRepository
{
    private readonly IApplicationDbContext _context;

    public TodoRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public List<Todo> GetAll()
    {
        return _context.Todos.AsNoTracking().ToList();
    }

    public Todo? GetById(Guid id)
    {
        return _context.Todos.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public void Add(Todo todo)
    {
        if (todo is null)
        {
            return;
        }

        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public void Update(Todo todo)
    {
        var existingTodo = GetById(todo.Id);
        if (existingTodo is null)
        {
            return;
        }

        _context.Todos.Update(todo);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var existingTodo = GetById(id);
        if (existingTodo is null)
        {
            return;
        }

        _context.Todos.Remove(existingTodo);
        _context.SaveChanges();
    }
}
