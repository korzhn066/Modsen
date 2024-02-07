using MediatR;
using Modsen.Application.Models;

namespace Modsen.Application.Features.Book.Queries
{
    public class GetAllBooks : IRequest<List<BookInformation>>
    {
        public int Page { get; set; }
        public int Count { get; set; }
    }
}
