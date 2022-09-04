using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Common
{
    public interface IBaseEfRepository<TModel> 
        where TModel : class
    {
        Task<List<TModel>> GetList(CancellationToken cancellationToken = default);
        
        Task<TModel> Get(Expression<Func<TModel, bool>> predicate = default, CancellationToken cancellationToken = default);
        
        Task<TModel> GetWithIncluding(Expression<Func<TModel, bool>> predicate = default, CancellationToken cancellationToken = default, params Expression<Func<TModel, object>>[] includeProperties);
        
        Task Add(TModel entity, CancellationToken cancellationToken = default);

        Task Update(TModel entity, CancellationToken cancellationToken = default);
        
        Task Remove(TModel entity, CancellationToken cancellationToken = default);
    }
}