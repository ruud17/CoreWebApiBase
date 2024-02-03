namespace CoreWebApiBase.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetEntityRepository<T>() where T : class;

        Task<int> SaveAsync();
    }
}