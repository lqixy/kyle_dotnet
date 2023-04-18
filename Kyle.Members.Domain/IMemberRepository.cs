using System.Linq.Expressions;

namespace Kyle.Members.Domain;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> Get();

    Task<Member> Get(long id);
    Task<Member> Get(string account);
    Task<bool> Exists(string account);
    Task<Member> Get(Expression<Func<Member, bool>> expression);

    Task Add(Member entity);

    Task Update(Member entity);
    
}