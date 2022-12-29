
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> Entity;

        protected GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            Entity = _context.Set<T>();

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                T item = await GetByIdAsync(id);
                Entity.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public IQueryable<T> GetAll()
        {
            try
            {
                return Entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await Entity.SingleOrDefaultAsync(s => s.ID == id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> InsertAsync(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Added;
                return obj;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public async Task<bool> UpdateAsync(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
