using Modsen.Data;
using Modsen.Domain.Entities;
using Modsen.Domain.Repositories;
using Modsen.Infrastructure.Repositories.Base;

namespace Modsen.Infrastructure.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(DBContext context) : base(context)
        {

        }
    }
}
