using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyExpenseTracker.Repository.Database;
using MyExpenseTracker.Repository.Interfaces;

namespace MyExpenseTracker.Repository.Implementations
{
    public class Repository<T>: IRepository<T> where T: class
    {
        protected readonly AppDbContext appDbContext;
        protected DbSet<T> dbSet;
        
        public Repository(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
            this.dbSet = appDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this.dbSet.RemoveRange(entities);
        }

        public T? Get(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = this.dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetRange(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = this.dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public async Task SaveAsync()
        {
            await this.appDbContext.SaveChangesAsync();
        }
    }
}
