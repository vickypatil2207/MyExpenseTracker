using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenseTracker.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        T? Get(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetRange(Expression<Func<T, bool>> filter);

        Task SaveAsync();
    }
}
