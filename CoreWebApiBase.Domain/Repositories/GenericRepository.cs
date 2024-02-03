using CoreWebApiBase.Domain.Data;
using CoreWebApiBase.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiBase.Domain.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly MovieContext _dbContext;
        private readonly DbSet<T> _table;

        public GenericRepository(MovieContext context)
        {
            _dbContext = context;
            _table = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}