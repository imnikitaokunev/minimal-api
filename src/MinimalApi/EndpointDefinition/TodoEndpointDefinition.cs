using MinimalApi.Models;
using MinimalApi.Repositories;

namespace MinimalApi.EndpointDefinition;

public class TodoEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/todos", GetAllTodos);
        app.MapGet("/api/todos/{id}", GetTodoById);
        app.MapPost("/api/todos", AddTodo);
        app.MapPut("/api/todos/{id}", UpdateTodo);
        app.MapDelete("/api/todos/{id}", DeleteTodo);
    }

    public IResult GetAllTodos(ITodoRepository todoRepository)
    {
        return Results.Ok(todoRepository.GetAll());
    }

    public IResult GetTodoById(ITodoRepository todoRepository, Guid id)
    {
        var todo = todoRepository.GetById(id);
        return todo is not null ? Results.Ok(todo) : Results.NotFound();
    }

    public IResult AddTodo(ITodoRepository todoRepository, Todo todo)
    {
        todoRepository.Add(todo);
        return Results.Created($"/api/todos/{todo.Id}", todo);
    }

    public IResult UpdateTodo(ITodoRepository todoRepository, Todo updatedTodo, Guid id)
    {
        var todo = todoRepository.GetById(id);
        if (todo is null)
        {
            return Results.NotFound();
        }

        todoRepository.Update(updatedTodo);
        return Results.Ok(updatedTodo);
    }

    public IResult DeleteTodo(ITodoRepository todoRepository, Guid id)
    {
        todoRepository.Delete(id);
        return Results.Ok();
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<ITodoRepository, TodoRepository>();
    }
}
