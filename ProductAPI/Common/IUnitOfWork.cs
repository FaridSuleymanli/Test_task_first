using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProductAPI.Common
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task SaveChangesAsync();

        Task CommitChangesAsync();

        Task RollBackAsync();

        void Dispose();
    }
}