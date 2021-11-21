using MinimalApi.Models;

namespace MinimalApi.Repositories;

internal class TodoRepository : ITodoRepository
{
    private readonly Dictionary<Guid, Todo> _todos = new();

    public List<Todo> GetAll()
    {
        return _todos.Values.ToList();
    }

    public Todo? GetById(Guid id)
    {
        return _todos.GetValueOrDefault(id);
    }

    public void Add(Todo todo)
    {
        if (todo is null)
        {
            return;
        }

        _todos[todo.Id] = todo;
    }

    public void Update(Todo todo)
    {
        var existingTodo = GetById(todo.Id);
        if (existingTodo is null)
        {
            return;
        }

        _todos[todo.Id] = todo;
    }

    public void Delete(Guid id)
    {
        _todos.Remove(id);
    }
}
