using Microsoft.EntityFrameworkCore;
using Piping.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Piping.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private PipingContext _dbContext { get; set; }
        internal DbSet<T> DbSet;
        public GenericRepository(PipingContext context)
        {
            this._dbContext = context;
            this.DbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }
        public IEnumerable<T> FindAll()
        {
            return this._dbContext.Set<T>().ToList();
        }
        public async Task<T> FindByIdAsync(int id)
        {
            return await this._dbContext.FindAsync<T>(id);
        }
        public T FindById(int id)
        {
            return  this._dbContext.Find<T>(id);
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this._dbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._dbContext.Set<T>().Where(expression).AsNoTracking().ToList();
        }

        public IQueryable<T> GenerateEntityAsIQueryable()
        {
            return this._dbContext.Set<T>();
        }

        public void Create(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._dbContext.Set<T>().Remove(entity);
        }
      
        public void RemoveRange(IEnumerable<T> entities)
        {
            this._dbContext.Set<T>().RemoveRange(entities);
        }



        public T CreateWithReturnEntity(T entity)
        {
            DbSet.Add(entity);
           _dbContext.SaveChanges();
            return entity;
        }
    }
}
