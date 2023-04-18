using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kyle.EntityFrameworkExtensions.Test.Models;

[Table("Todo")]
public class Todo
{
    [Key]
    public int Id { get; set; }

    public string Content { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime CompletedTime { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsMark { get; set; }

    public Guid UserId { get; set; }

    public bool IsDeleted { get; set; }
}