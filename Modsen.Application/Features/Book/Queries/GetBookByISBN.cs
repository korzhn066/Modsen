using MediatR;
using Modsen.Application.Models;

namespace Modsen.Application.Features.Book.Queries
{
    public class GetBookByISBN : IRequest<BookInformation>
    {
        public string ISBN { get; set; } = null!;
    }
}
