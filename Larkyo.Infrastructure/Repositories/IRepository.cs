using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> FindAll();
        T SingleOrDefault(Expression<Func<T, bool>> expression);
    }
}
