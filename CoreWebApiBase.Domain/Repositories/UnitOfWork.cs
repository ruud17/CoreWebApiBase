using CoreWebApiBase.Domain.Data;
using CoreWebApiBase.Domain.Interfaces;

namespace CoreWebApiBase.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieContext _dbContext;

        public UnitOfWork(MovieContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IGenericRepository<T> GetEntityRepository<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
