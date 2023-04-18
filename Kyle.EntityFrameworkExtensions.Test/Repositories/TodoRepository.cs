using Kyle.EntityFrameworkExtensions.Test.DbContextes;
using Kyle.EntityFrameworkExtensions.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Kyle.EntityFrameworkExtensions.Test.Repositories;

public class TodoRepository: EfCoreRepositoryBase<Todo>

    //EfCoreRepositoryBase<TodosDbContext ,Todo>
{
    public TodoRepository(TodosDbContextTest context): base(context)
    {
    }

    public async Task<IEnumerable<Todo>> Get()
    {
        return await dbSet.ToListAsync();
    }

}