using Kyle.EntityFrameworkExtensions;
using Kyle.Todos.Domain;
using Kyle.Todos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kyle.Todos.EntityFramework;

public class TodoRepository: EfCoreRepositoryBase<Todo>
   , ITodoRepository
{
    public TodoRepository(TodosDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Todo>> Get(long userId)
    {
        return await dbSet.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<Todo> Get(int id)
    {
        return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Insert(Todo entity)
    { 
        await dbSet.AddAsync(entity);
        return await Context.SaveChangesAsync();
    }

    public async Task<int> Update(Todo entity)
    {
        dbSet.Update(entity);
        return await Context.SaveChangesAsync();
    }


    public async Task<int> Delete(Todo entity)
    {
        // throw new NotImplementedException();
        dbSet.Remove(entity);
        return await Context.SaveChangesAsync();
    }

}