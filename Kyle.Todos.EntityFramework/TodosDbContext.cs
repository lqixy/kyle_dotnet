using Kyle.EntityFrameworkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Kyle.Todos.EntityFramework;

public class TodosDbContext: KyleDbContextBase
{
    public TodosDbContext(DbContextOptions<TodosDbContext> options): base(options){}

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}