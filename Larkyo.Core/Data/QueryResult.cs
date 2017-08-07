using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Data;

namespace Larkyo.Core.Data
{
    public class QueryResult<T> : IQueryResult<T>
    {
        public QueryResult(IEnumerable<T> items, int totalCount)
        {
            this.Items = items;
            this.TotalCount = totalCount;
        }

        public int TotalCount { get; private set; }
        public IEnumerable<T> Items { get; private set; }
    }
}
