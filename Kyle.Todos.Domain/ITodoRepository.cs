using Kyle.Todos.Domain.Entities;

namespace Kyle.Todos.Domain;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> Get(long userId);

    Task<Todo> Get(int id);

    Task<int> Insert(Todo entity);

    Task<int> Update(Todo entity);

    // Task<int> Save(Todo entity);

    Task<int> Delete(Todo entity);
}