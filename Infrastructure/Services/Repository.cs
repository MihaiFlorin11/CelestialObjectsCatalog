using Application.Abstraction;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Services
{
    public class Repository<T>(DatabaseContext context) : IRepository<T> where T : BaseEntityModel
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public T Add(T entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            return this._dbSet.Add(entity).Entity;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var entityToBeDeleted = await this.GetByIdAsync(id);
            entityToBeDeleted.IsDeleted = true;
            return this._dbSet.Update(entityToBeDeleted) is not null;
        }

        public IEnumerable<T> Find(Func<T, bool> searchCriteria)
        {
            return this._dbSet.Where(searchCriteria).ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> searchCriteria, string includePropertyByName)
        {
            var result = this._dbSet.Where(searchCriteria);
            if (!string.IsNullOrEmpty(includePropertyByName))
            {
                result = result.Include(includePropertyByName);
            }
            return result.ToList();
        }

        public IEnumerable<T> Find(Func<T, bool> searchCriteria, int skip, int take)
        {
            return this._dbSet.Where(searchCriteria).Skip(skip).Take(take).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public T Update(T entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            return this._dbSet.Update(entity).Entity;
        }
    }
}
