using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kyle.EntityFrameworkExtensions;

namespace Kyle.Members.Domain;

[Table("Member")]
public class Member: AggregateRoot<long>
{
    [Key]
    public long Id { get; set; }

    public string? Account { get; set; }

    public string? UserName { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreationTime { get; set; }
    
    
}