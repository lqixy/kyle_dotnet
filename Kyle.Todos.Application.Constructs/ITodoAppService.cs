namespace Kyle.Todos.Application.Constructs;

public interface ITodoAppService
{
    Task<IEnumerable<TodoDto>> Get(long userId);

    Task<TodoDto> Get(int id);
    Task Add(TodoDto dto);
}