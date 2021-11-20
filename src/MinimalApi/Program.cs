using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TodoRepository>();

var app = builder.Build();

app.MapGet("/api/todos", ([FromServices] TodoRepository todoRepository) => todoRepository.GetAll());

app.MapGet("/api/todos/{id}", ([FromServices] TodoRepository todoRepository, Guid id) =>
{
    var todo = todoRepository.GetById(id);
    return todo is not null ? Results.Ok(todo) : Results.NotFound();
});

app.MapPost("/api/todos", ([FromServices] TodoRepository todoRepository, Todo todo) =>
{
    todoRepository.Add(todo);
    return Results.Created($"/api/todos/{todo.Id}", todo);
});

app.MapPut("/api/todos/{id}", ([FromServices] TodoRepository todoRepository, Todo updatedTodo, Guid id) =>
{
    var todo = todoRepository.GetById(id);
    if(todo is null)
    {
        return Results.NotFound();
    }

    todoRepository.Update(updatedTodo);
    return Results.Ok(updatedTodo);
});

app.MapDelete("/api/todos/{id}", ([FromServices] TodoRepository todoRepository, Guid id) =>
{
    todoRepository.Delete(id);
    return Results.Ok();
});

app.Run();

internal record Todo(Guid Id, string Name, bool IsCompleted);

internal class TodoRepository
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
