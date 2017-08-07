using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Data
{
    public interface IQueryResult<T>
    {
        int TotalCount { get; }
        IEnumerable<T> Items { get; }
    }
}
