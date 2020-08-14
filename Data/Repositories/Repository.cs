using Data.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IDataContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(IDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
            => _dbSet.Add(entity);

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.AnyAsync(predicate);

        public async Task<int> CountAsync()
            => await _dbSet.CountAsync();

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.CountAsync(predicate);

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
            => await _dbSet.Where(predicate).ToListAsync();

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);

        public async Task<TEntity> GetByIdAsync(long id)
            => await GetAsync(r => r.Id == id);

        public void Remove(TEntity entity)
                                    => _dbSet.Remove(entity);
    }
}