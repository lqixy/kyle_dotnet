﻿using Kyle.EntityFrameworkExtensions;
using Kyle.Members.Domain;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyle.Mall.Context;

namespace Kyle.Members.EntityFramework
{
    public class UserOperationRepository : EfCoreRepositoryBase< UserInfo>, IUserOperationRepository
    {
        public UserOperationRepository(MembersDbContext context) : base(context)
        {
        }

        public async Task Insert(UserInfo entity)
        {
            await dbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Insert(IEnumerable<UserInfo> entities)
        {
            dbSet.AddRange(entities);

            await Context.SaveChangesAsync();
        }

    }

    //public class DbContextInterceptor : SaveChangesInterceptor
    //{
    //    public override 
    //}
}
