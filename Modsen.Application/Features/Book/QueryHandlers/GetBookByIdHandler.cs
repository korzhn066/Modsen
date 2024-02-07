using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Modsen.Application.Features.Book.Queries;
using Modsen.Application.Models;
using Modsen.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Application.Features.Book.QueryHandlers
{
    internal class GetBookByIdHandler : IRequestHandler<GetBookById, BookInformation>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookInformation> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookWithGenersByIdAsync(request.Id, cancellationToken);

            if (book is null)
                throw new NullReferenceException(nameof(book));

            var bookInforamtion = _mapper.Map<BookInformation>(book);

            if (bookInforamtion is null)
                throw new NullReferenceException(nameof(bookInforamtion));

            bookInforamtion.Geners = book.BookGenres.Select(bg => bg.Genre.Name).ToList();

            return bookInforamtion;
        }
    }
}
