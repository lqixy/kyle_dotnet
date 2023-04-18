using Kyle.Todos.Application.Constructs;

namespace Kyle.Todos.ViewModels;

public class GetTodosResult
{
    public GetTodosResult(IEnumerable<TodoDto> list)
    {
        this.List = list;
    }

    public IEnumerable<TodoDto> List { get; set; } = Enumerable.Empty<TodoDto>();
}