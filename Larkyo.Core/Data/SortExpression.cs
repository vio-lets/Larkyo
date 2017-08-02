using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Data;

namespace Larkyo.Core.Data
{
    class SortExpression<T, K> : PropertyExpression<T, K>, ISortExpression<T>
    {

        public SortExpression(Expression<Func<T, K>> sortExpression, SortDirection sortDirection)
            : base(sortExpression)
        {
            this.SortDirection = sortDirection;
        }

        public SortDirection SortDirection
        {
            get;
            private set;
        }

        public IOrderedQueryable<T> Apply(IQueryable<T> queryable)
        {
            switch (this.SortDirection)
            {
                case SortDirection.Ascending:
                    return queryable.OrderBy(this.Expression);
                case SortDirection.Descending:
                    return queryable.OrderByDescending(this.Expression);
                default:
                    return null;
            }
        }

        public IOrderedQueryable<T> Apply(IOrderedQueryable<T> queryable)
        {
            switch (this.SortDirection)
            {
                case SortDirection.Ascending:
                    return queryable.ThenBy(this.Expression);
                case SortDirection.Descending:
                    return queryable.ThenByDescending(this.Expression);
                default:
                    return null;
            }
        }
    }
}
