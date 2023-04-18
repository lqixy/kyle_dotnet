using Kyle.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyle.EntityFrameworkExtensions
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository
    {
    }

    public abstract class EfCoreRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
        // where TContext : KyleDbContextBase
    {
        protected KyleDbContextBase Context;
        protected DbSet<TEntity> dbSet;

        public EfCoreRepositoryBase(KyleDbContextBase context)
        {
            Context = context;
            dbSet = Context.Set<TEntity>();
        }
    }
    //public abstract class EfCoreRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    //    // where TContext : KyleDbContextBase
    //{
    //    protected KyleDbContext Context;
    //    protected DbSet<TEntity> dbSet;

    //    public EfCoreRepositoryBase(KyleDbContext context)
    //    {
    //        Context = context;
    //        dbSet = Context.Set<TEntity>();
    //    }
    //}
}