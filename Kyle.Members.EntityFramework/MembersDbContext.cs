using Kyle.EntityFrameworkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Kyle.Members.EntityFramework;

public class MembersDbContext: KyleDbContextBase
{
    public MembersDbContext(DbContextOptions<MembersDbContext> options): base(options){}
}