using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Data
{
    public interface IQueryConfiguration<T>
    {
        bool IsPaged { get; }
        int PageNumber { get; }
        int PageSize { get; }
        IQueryConfiguration<T> Page(int pageNumber, int pageSize);
        ICollection<Expression<Func<T, bool>>> FilterExpressions { get; }
        IQueryConfiguration<T> FilterBy(Expression<Func<T, bool>> filterExpression);
        ICollection<ISortExpression<T>> SortExpressions { get; }
        IQueryConfiguration<T> SortBy<TProperty>(Expression<Func<T, TProperty>> sortExpression, SortDirection sortDirection = SortDirection.Ascending);
    }
}
