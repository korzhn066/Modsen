using MediatR;
using Modsen.Application.Models;

namespace Modsen.Application.Features.Book.Queries
{
    public class GetBookById : IRequest<BookInformation>
    {
        public int Id { get; set; }
    }
}
