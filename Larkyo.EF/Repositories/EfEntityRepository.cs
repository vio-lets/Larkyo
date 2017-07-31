using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Repositories;

namespace Larkyo.EF.Repositories
{
    public abstract class EfEntityRepository<T, TContext> : IRepository<T>
        where T : class, new()
        where TContext : DbContext, new()
    {
        public IEnumerable<T> FindAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(expression);
            }
        }
    }
}
