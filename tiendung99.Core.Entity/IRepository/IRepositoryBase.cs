using System.Linq.Expressions;

namespace tiendung99.Core.Entity.IRepository
{
    public interface IRepositoryBase<TEntity, TModel> where TEntity : class, new() where TModel : class
    {
        Task AddAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(Guid id);
        Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> expression);
        Task<IEnumerable<TModel>> PagingAsync(Expression<Func<TModel, bool>> expression, int page, int pageSize);
        Task UpdateRangeAsync(IEnumerable<TModel> models);
        Task DeleteRangeAsync(IEnumerable<TModel> models);
        Task AddRangeAsync(IEnumerable<TModel> models);
        Task<bool> CheckExist(TModel model);
        Task SaveAsync();
    }
}
