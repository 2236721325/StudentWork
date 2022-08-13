using Microsoft.EntityFrameworkCore;
using Shared.Commons;
using System.Linq.Expressions;

namespace Shared.BaseRepositorys
{

    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected DbContext db;
        public DbSet<T> DbSet { get; set; }
        public BaseRepository(DbContext context)
        {
            db = context;
            DbSet = db.Set<T>();
        }

        public async Task<int> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
            return await db.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = await FindAsync(id);
            return await RemoveAsync(entity);
        }

        public async Task<int> RemoveAsync(T entity)
        {
            DbSet.Remove(entity);
            return await db.SaveChangesAsync();

        }

        public async Task<int> RemoveRangeAsync(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
            return await db.SaveChangesAsync();
        }

        public async ValueTask<T> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
          
        }

        public async Task<IQueryable<T>> Query(bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            return await Task.FromResult(query);
            
        }

        public async Task<IQueryable<T>> Query(Expression<Func<T, bool>> func, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            return await Task.FromResult( query.Where(func));
        }

        public async Task<IQueryable<T>> Query(int pageIndex, int size, RefAsync<int> total, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            var qresult = query.Skip((pageIndex - 1) * size).Take(size);
            total.Value = query.Count();
            return await Task.FromResult(qresult);

        }

        public async Task<IQueryable<T>> Query(Expression<Func<T, bool>> func, int pageIndex, int size, RefAsync<int> total, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            var qresult = query.Where(func).Skip((pageIndex - 1) * size).Take(size);
            total.Value = query.Count();
            return await Task.FromResult(qresult);
        }
    }
}

