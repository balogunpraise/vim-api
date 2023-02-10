namespace Vim.Core.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(string id);
        Task<bool> AddAsync(T entity);
        Task<bool> Upsert(T entity);
        Task<bool> Delete(string id);
    }
}
