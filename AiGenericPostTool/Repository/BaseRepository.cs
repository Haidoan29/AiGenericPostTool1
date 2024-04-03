using AiGenericPostTool.Data;
using AiGenericPostTool.Models;
using Microsoft.EntityFrameworkCore;

namespace AiGenericPostTool.Repository
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> FilterAsync(string keyword, string orderColumn, bool isAsc, int pageIndex, int pageSize, out int totalPage);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        //DI 
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            if (entity != null)
            {
                var result = await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<T> DeleteAsync(int id)
        {
            if (id > 0)
            {
                var affected = await _dbSet.FindAsync(id);
                if (affected != null)
                {
                    //soft delete
                    affected.IsDelete = true;
                    affected.DeletedDate = DateTime.Now;

                    _dbSet.Update(affected);
                    await _context.SaveChangesAsync();
                    return affected;
                }

            }
            return null;
        }

        public Task<List<T>> FilterAsync(string keyword, string orderColumn, bool isAsc, int pageIndex, int pageSize, out int totalPage)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var ls = await _dbSet.Where(r => r.IsDelete == false).ToListAsync();
            return ls;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var result = await _dbSet.FindAsync(id);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity != null)
            {
                entity.UpdatedDate = DateTime.Now;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
