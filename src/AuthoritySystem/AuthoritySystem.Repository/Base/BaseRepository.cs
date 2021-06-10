using AuthoritySystem.EFCore.Context;
using AuthoritySystem.Model.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthoritySystem.Repository.Base
{

    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(AppDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public async Task<int> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? await _dbSet.FirstOrDefaultAsync(predicate) : await _dbSet.FirstOrDefaultAsync();
        }

        public Task<int> UpdateAsync(T entity, Expression<Func<T, object>>[] updatedProperties)
        {
            _dbContext.Set<T>().Attach(entity);
            if (updatedProperties.Any())
            {
                foreach (var property in updatedProperties)
                {
                    _dbContext.Entry(entity).Property(property).IsModified = true;
                }
            }
            return _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllListAsync(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? await _dbSet.Where(predicate).ToListAsync() : await _dbSet.ToListAsync();
        }
    }
}
