using MinimalApi.Models;

namespace MinimalApi.Repositories;

public interface ITodoRepository
{
    List<Todo> GetAll();
    Todo? GetById(Guid id);
    void Add(Todo todo);
    void Update(Todo todo);
    void Delete(Guid id);
}
