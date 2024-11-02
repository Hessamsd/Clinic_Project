using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Framework.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {

        private readonly DbContext  _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Add(T command)
        {
            await _dbSet.AddAsync(command);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TKey id)
        {
            var command = await GetById(id);
            if (command != null)
            {
                _dbSet.Remove(command);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task Update(T command)
        {
            _dbSet.Update(command);
            await _context.SaveChangesAsync();
        }
    }
}
