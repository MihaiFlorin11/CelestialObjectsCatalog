using System.Linq.Expressions;

namespace Application.Abstraction
{
    public interface IRepository<T> where T : BaseEntityModel
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(long id);

        T Add(T entity);

        Task<bool> DeleteByIdAsync(long id);

        T Update(T entity);

        IEnumerable<T> Find(Func<T, bool> searchCriteria);

        IEnumerable<T> Find(Func<T, bool> searchCriteria, int skip, int take);

        IEnumerable<T> Find(Expression<Func<T, bool>> searchCriteria, string includePropertyByName);
    }
}
