using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;

namespace ProductAPI.Common
{
    public class BaseEfRepository<TModel> : IBaseEfRepository<TModel> 
        where TModel : class
    {
        private readonly ProductDbContext _dbContext;
        private DbSet<TModel> Table => _dbContext.Set<TModel>();
        public IUnitOfWork UnitOfWork;

        public BaseEfRepository(ProductDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            UnitOfWork = unitOfWork;
        }
        
        public async Task<List<TModel>> GetList(CancellationToken cancellationToken = default)
        {
            IQueryable<TModel> query = Table;
            return await query.ToListAsync(cancellationToken: cancellationToken);
        }

        public Task<TModel> Get(Expression<Func<TModel, bool>> predicate = default, CancellationToken cancellationToken = default)
        {
            return Table.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken: cancellationToken);
        }

        public Task<TModel> GetWithIncluding(Expression<Func<TModel, bool>> predicate = default, CancellationToken cancellationToken = default,
            params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> inquery = Table;
            inquery = includeProperties.Aggregate(inquery, (current, includeProperty) => current.Include(includeProperty));
            return inquery.FirstOrDefaultAsync(predicate, cancellationToken: cancellationToken);
        }

        public async Task Add(TModel entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(TModel entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Remove(TModel entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}