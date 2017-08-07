using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Core.Data;
using Larkyo.Infrastructure.Data;
using Larkyo.Infrastructure.Repositories;

namespace Larkyo.EF.Repositories
{
    public abstract class EfEntityRepository<T, TContext> : IRepository<T>
        where T : class, new()
        where TContext : DbContext, new()
    {
        public IQueryConfiguration<T> CreateQueryConfiguration()
        {
            return new QueryConfiguration<T>();
        }

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

        public virtual T FindSingle(IQueryConfiguration<T> queryConfiguration)
        {
            return this.Find(queryConfiguration).Items.FirstOrDefault();
        }

        public virtual IQueryResult<T> Find(IQueryConfiguration<T> queryConfiguration)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> items = context.Set<T>();

                return this.Find(queryConfiguration, items);
            }
        }

        protected IQueryResult<T> Find(IQueryConfiguration<T> queryConfiguration, IQueryable<T> items)
        {
            items = Filter(queryConfiguration, items);

            items = Sort(queryConfiguration, items);

            int total = items.Count();

            items = Paginate(queryConfiguration, items);

            return new QueryResult<T>(items.ToList(), total);
        }

        protected IQueryable<T> Filter(IQueryConfiguration<T> queryConfiguration, IQueryable<T> items)
        {
            if (queryConfiguration.FilterExpressions != null)
            {
                foreach (Expression<Func<T, bool>> filterExpression in queryConfiguration.FilterExpressions)
                {
                    items = items.Where(filterExpression);
                }
            }

            return items;
        }

        protected IQueryable<T> Sort(IQueryConfiguration<T> queryConfiguration, IQueryable<T> items)
        {
            if (queryConfiguration.SortExpressions != null && queryConfiguration.SortExpressions.Any())
            {
                IOrderedQueryable<T> orderedItems = null;
                foreach (var sortExpression in queryConfiguration.SortExpressions)
                {
                    if (orderedItems == null)
                    {
                        orderedItems = sortExpression.Apply(items);
                    }
                    else
                    {
                        orderedItems = sortExpression.Apply(orderedItems);
                    }
                }
                items = orderedItems;
            }

            return items;
        }

        protected IQueryable<T> Paginate(IQueryConfiguration<T> queryConfiguration, IQueryable<T> items)
        {
            if (queryConfiguration.IsPaged)
            {
                items = items
                    .Skip((queryConfiguration.PageNumber - 1) * queryConfiguration.PageSize)
                    .Take(queryConfiguration.PageSize);
            }

            return items;
        }
    }
}
