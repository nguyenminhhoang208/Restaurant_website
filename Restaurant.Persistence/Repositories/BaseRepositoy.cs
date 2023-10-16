using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;
using Restaurant.Persistence.DatabaseContext;

namespace Restaurant.Persistence.Repositories
{
    public class BaseRepositoy<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        public BaseRepositoy(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return  entity.Id;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task<int> UpdateAsync(T entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
           await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
