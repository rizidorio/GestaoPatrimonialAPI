using GestaoPatrimonial.Data.Context;
using GestaoPatrimonial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int? id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = _context.Add(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = _context.Attach(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
