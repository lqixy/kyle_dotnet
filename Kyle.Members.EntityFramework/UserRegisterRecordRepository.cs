using Kyle.EntityFrameworkExtensions;
using Kyle.Members.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyle.Mall.Context;

namespace Kyle.Members.EntityFramework
{
    public class UserRegisterRecordRepository : EfCoreRepositoryBase<UserRegisterRecord>, IUserRegisterRecordRepository
    {
        public UserRegisterRecordRepository(MembersDbContext context) : base(context)
        {
        }


        public async Task Insert(UserRegisterRecord record)
        {
            await dbSet.AddAsync(record);
            await Context.SaveChangesAsync();
        }



    }
}
