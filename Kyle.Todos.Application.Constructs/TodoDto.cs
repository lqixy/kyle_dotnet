namespace Kyle.Todos.Application.Constructs;

public class TodoDto
{
    // public TodoDto()
    // {
    //     CreatedTime
    // }

    public long Id { get; set; }

    public string Content { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.Now;

    public DateTime? CompletedTime { get; set; }

    public bool IsCompleted { get; set; } = false;

    public bool IsMark { get; set; } = false;

    public Guid UserId { get; set; }

    public bool IsDeleted { get; set; } = false;

    public void BuildId(long id)
    {
        Id = id;
    }
}