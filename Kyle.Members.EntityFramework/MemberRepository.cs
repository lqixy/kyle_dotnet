using System.Linq.Expressions;
using Kyle.EntityFrameworkExtensions;
using Kyle.Members.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kyle.Members.EntityFramework;

public class MemberRepository: EfCoreRepositoryBase<Member> , IMemberRepository
{
    public MemberRepository(MembersDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Member>> Get()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<Member> Get(long id)
    {
        return await dbSet.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<bool> Exists(string account)
    {
        return await dbSet.AnyAsync(x => x.Mobile == account
                                         || x.UserName == account || x.Email == account);
    }
    public async Task<Member> Get(string account)
    {
        return await dbSet.FirstOrDefaultAsync(x => x.Mobile == account
                                                    || x.Account == account || x.Email == account);
    }
    public async Task<Member> Get(Expression<Func<Member, bool>> expression)
    {
        try
        {

            return await dbSet.FirstOrDefaultAsync(expression);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task Add(Member entity)
    {
        await dbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task Update(Member entity)
    {
        dbSet.Update(entity);
        await Context.SaveChangesAsync();
    }
}