using MediatR;
using Modsen.Application.Features.Book.Commands;
using Modsen.Application.Models;
using Modsen.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Application.Features.Book.CommandHandlers
{
    internal class UpdateBookHandler : IRequestHandler<UpdateBook>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);

            if (book is null)
                throw new NullReferenceException(nameof(book));

            book.Name = request.Name;

            await _bookRepository.SaveChangesAsync();
        }
    }
}
