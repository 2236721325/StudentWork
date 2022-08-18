using Shared.BaseRepositorys;
using Shared.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BaseServices
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected IBaseRepository<T> repository;//从子类构造参收传入 这样能避免泛型注入 虽然可以实现泛型注入 但最好不那么做 有坑
       

        public async Task<int> AddAsync(T entity)
        {
            return await repository.AddAsync(entity);
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            return await repository.AddRangeAsync(entities);
        }

        public async ValueTask<T> FindAsync(int id)
        {
            return await repository.FindAsync(id);
        }

        public async Task<IQueryable<T>> Query(bool disableTracking = true)
        {
            return await repository.Query(disableTracking);
        }

        public async Task<IQueryable<T>> Query(Expression<Func<T, bool>> func, bool disableTracking = true)
        {
            return await repository.Query(func,disableTracking);
        }

        public async Task<IQueryable<T>> Query(int pageIndex, int size, RefAsync<int> total, bool disableTracking = true)
        {
            return await repository.Query(pageIndex,size,total,disableTracking);
        }

        public async Task<IQueryable<T>> Query(Expression<Func<T, bool>> func, int pageIndex, int size, RefAsync<int> total, bool disableTracking = true)
        {
            return await repository.Query(func,pageIndex,size,total,disableTracking);
        }

        public async Task<int> RemoveAsync(int id)
        {
            return await repository.RemoveAsync(id);
        }

        public async Task<int> RemoveAsync(T entity)
        {
            return await repository.RemoveAsync(entity);
        }

        public async Task<int> RemoveRangeAsync(IEnumerable<T> entities)
        {
            return await repository.RemoveRangeAsync(entities);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<T> entities)
        {
            return await repository.UpdateRangeAsync(entities);
        }
    }
}
