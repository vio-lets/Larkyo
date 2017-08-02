using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Data
{
    public interface ISortExpression<T>
    {
        SortDirection SortDirection { get; }
        IOrderedQueryable<T> Apply(IQueryable<T> queryable);
        IOrderedQueryable<T> Apply(IOrderedQueryable<T> queryable);
    }
}
