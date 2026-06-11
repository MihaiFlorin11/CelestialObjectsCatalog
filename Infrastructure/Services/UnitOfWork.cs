using Application.Abstraction;
using Infrastructure.Context;

namespace Infrastructure.Services
{
    public class UnitOfWork(DatabaseContext databaseContext) : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public IRepository<T> GetRepository<T>() where T : BaseEntityModel
        {
            return new Repository<T>(this._databaseContext);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this._databaseContext.SaveChangesAsync() > 0;
        }
    }
}
