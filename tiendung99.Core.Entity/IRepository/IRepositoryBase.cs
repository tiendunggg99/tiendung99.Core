using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace tiendung99.Core.Entity.IRepository
{
    public interface IRepositoryBase<TEntity,TModel> where TEntity : class, new() where TModel : class
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> PagingAsync(Expression<Func<TEntity, bool>> expression,int? page, int? pageSize);
        Task UpdateRangeAsync(IEnumerable<TModel> models);
        Task DeleteRangeAsync(IEnumerable<TModel> models);
        Task AddRangeAsync(IEnumerable<TModel> models);
        Task SaveAsync();


    }
}
