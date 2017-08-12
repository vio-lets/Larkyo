using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Data;

namespace Larkyo.Infrastructure.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IQueryConfiguration<T> CreateQueryConfiguration();

        IEnumerable<T> FindAll();
        T SingleOrDefault(Expression<Func<T, bool>> expression);
        T FindSingle(IQueryConfiguration<T> queryConfiguration);
        IQueryResult<T> Find(IQueryConfiguration<T> queryConfiguration);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
