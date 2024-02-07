using MediatR;

namespace Modsen.Application.Features.Book.Commands
{
    public class DeleteBook : IRequest
    {
        public int Id { get; set; }
    }
}
