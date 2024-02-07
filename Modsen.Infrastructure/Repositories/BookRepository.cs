using Microsoft.EntityFrameworkCore;
using Modsen.Data;
using Modsen.Domain.Entities;
using Modsen.Domain.Repositories;
using Modsen.Domain.Repositories.Base;
using Modsen.Infrastructure.Repositories.Base;
using System.Linq.Expressions;

namespace Modsen.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(DBContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<Book>> GetAllBooksWithGenersByIdAsync(int page, int count, CancellationToken cancellationToken = default)
        {
            var book = await Context.Books
                .Skip(page * count)
                .Take(count)
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .ToListAsync(cancellationToken);

            return book;
        }

        public async Task<Book?> GetBookWithGenersByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var book = await Context.Books
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

            return book;
        }

        public async Task<Book?> GetBookWithGenersByConditionAsync(Expression<Func<Book, bool>> expression, CancellationToken cancellationToken = default)
        {
            var book = await Context.Books
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(expression, cancellationToken);

            return book;
        }
    }
}
