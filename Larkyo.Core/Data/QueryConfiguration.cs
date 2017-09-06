using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Data;

namespace Larkyo.Core.Data
{
    public class QueryConfiguration<T> : IQueryConfiguration<T>
    {
        public QueryConfiguration()
        {
            this.PageNumber = 0;
            this.PageSize = 0;
            this.IsPaged = false;
            _filterExpressions = new List<Expression<Func<T, bool>>>();
            _sortExpressions = new List<ISortExpression<T>>();
        }

        public bool IsPaged { get; private set; }

        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }

        public IQueryConfiguration<T> Page(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.IsPaged = true;
            return this;
        }

        private ICollection<Expression<Func<T, bool>>> _filterExpressions;

        public ICollection<Expression<Func<T, bool>>> FilterExpressions
        {
            get
            {
                return _filterExpressions;
            }
        }

        public IQueryConfiguration<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            this.FilterExpressions.Add(filterExpression);
            return this;
        }

        private ICollection<ISortExpression<T>> _sortExpressions;

        public ICollection<ISortExpression<T>> SortExpressions
        {
            get
            {
                return _sortExpressions;
            }
        }

        public IQueryConfiguration<T> SortBy<K>(Expression<Func<T, K>> sortExpression, SortDirection sortDirection = SortDirection.Ascending)
        {
            this.SortExpressions.Add(new SortExpression<T, K>(sortExpression, sortDirection));
            return this;
        }
    }
}
