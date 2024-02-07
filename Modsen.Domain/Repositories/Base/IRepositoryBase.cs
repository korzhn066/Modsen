using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modsen.Domain.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
