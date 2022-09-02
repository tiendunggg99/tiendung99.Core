using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using tiendung99.Core.Entity.IRepository;

namespace tiendung99.Core.Entity.Repository
{
    public class RepositoryBase<TEntity, TModel> : IRepositoryBase<TEntity, TModel> where TEntity : class, new() where TModel : class

    {
        private readonly IMapper _mapper;
        private readonly DbContext _context;
        public RepositoryBase(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task AddAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _context.Set<TEntity>().AddAsync(entity);
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<TModel> models)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(models);
            await _context.Set<TEntity>().AddRangeAsync(entities);
            throw new NotImplementedException();
        }

        public async Task<bool> CheckExist(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            if (await _context.Set<TEntity>().FindAsync(entity) != null)
            {
                return true;
            }
            return false;
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _context.Set<TEntity>().Remove(entity);
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<TModel> models)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(models);
            _context.Set<TEntity>().RemoveRange(entities);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> expressionModel)
        {
            var expression = _mapper.Map<Expression<Func<TEntity, bool>>>(expressionModel);
            var entities = await _context.Set<TEntity>().Where(expression).ToListAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
            throw new NotImplementedException();
        }

        public async Task<TModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<TModel>().FindAsync(id);
            return _mapper.Map<TModel>(entity);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> PagingAsync(Expression<Func<TModel, bool>> expression, int page, int pageSize)
        {
            var emtities = await _context.Set<TModel>().Where(expression).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return _mapper.Map<IEnumerable<TModel>>(emtities);
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _context.Set<TEntity>().Update(entity);
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<TModel> models)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(models);
            _context.UpdateRange(entities);
            throw new NotImplementedException();
        }
    }
}
