using Kyle.EntityFrameworkExtensions.Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyle.EntityFrameworkExtensions.Test.DbContextes;

namespace Kyle.EntityFrameworkExtensions.Test.Repositories
{
    public class UserInfoRepository : EfCoreRepositoryBase<UserInfo>
    {
        public UserInfoRepository(MallDbContextTest context) : base(context)
        {
        }


        public async Task<IEnumerable<UserInfo>> Get()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<bool> Save(UserInfo entity)
        {
            await dbSet.AddAsync(entity);

            return (await Context.SaveChangesAsync()) > 0;
        }
    }
}