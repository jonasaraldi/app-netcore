using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetByIdAsync(long id);

        void Remove(TEntity entity);
    }
}