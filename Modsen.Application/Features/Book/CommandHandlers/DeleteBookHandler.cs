using MediatR;
using Modsen.Application.Features.Book.Commands;
using Modsen.Domain.Repositories;

namespace Modsen.Application.Features.Book.CommandHandlers
{
    internal class DeleteBookHandler : IRequestHandler<DeleteBook>
    {
        private readonly IBookRepository _bookRepositorie;
        public DeleteBookHandler(IBookRepository bookRepositorie) 
        { 
            _bookRepositorie = bookRepositorie;
        }
        public async Task Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            var book = await _bookRepositorie.GetByIdAsync(request.Id, cancellationToken);

            if (book is null) 
                throw new ArgumentNullException(nameof(book));

            _bookRepositorie.Delete(book);

            await _bookRepositorie.SaveChangesAsync();
        }
    }
}
