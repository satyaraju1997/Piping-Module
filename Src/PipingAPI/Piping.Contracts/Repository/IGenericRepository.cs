using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Piping.Contracts.Repository
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        T FindById(int id);
        Task<T> FindByIdAsync(int id);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);           
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GenerateEntityAsIQueryable();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T CreateWithReturnEntity(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
