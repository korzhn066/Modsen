using Modsen.Domain.Entities;
using Modsen.Domain.Repositories.Base;
using System.Linq.Expressions;

namespace Modsen.Domain.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book> 
    {
        Task<Book?> GetBookWithGenersByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Book?> GetBookWithGenersByConditionAsync(Expression<Func<Book, bool>> expression, CancellationToken cancellationToken = default);
        Task<List<Book>> GetAllBooksWithGenersByIdAsync(int page, int count, CancellationToken cancellationToken = default);
    }
}
