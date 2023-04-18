using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kyle.EntityFrameworkExtensions;

namespace Kyle.Todos.Domain.Entities;

[Table("Todo")]
public class Todo: AggregateRoot<long>
{
    [Key]
    public long Id { get; set; }

    public string Content { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? CompletedTime { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsMark { get; set; }

    public long UserId { get; set; }

    public bool IsDeleted { get; set; }

}