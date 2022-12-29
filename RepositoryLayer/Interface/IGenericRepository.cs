using DataAccessLayer.Entities;

namespace Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(Guid id);
        Task<T> InsertAsync(T obj);
    }
}
