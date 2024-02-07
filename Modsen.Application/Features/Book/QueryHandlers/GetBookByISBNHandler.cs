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
    internal class GetBookByISBNHandler : IRequestHandler<GetBookByISBN, BookInformation>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookByISBNHandler(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookInformation> Handle(GetBookByISBN request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookWithGenersByConditionAsync(b => b.ISBN == request.ISBN, cancellationToken);

            if (book is null) 
                throw new NullReferenceException(nameof(book));

            var bookInforamtion = _mapper.Map<BookInformation>(book);

            if (bookInforamtion is null)
                throw new NullReferenceException(nameof(book));

            bookInforamtion.Geners = book.BookGenres.Select(bg => bg.Genre.Name).ToList();

            return bookInforamtion;
        }
    }
}
