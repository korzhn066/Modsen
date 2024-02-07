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
    internal class GetAllBooksHandler : IRequestHandler<GetAllBooks, List<BookInformation>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksHandler(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookInformation>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooksWithGenersByIdAsync(request.Page, request.Count, cancellationToken);

            var bookInformations = new List<BookInformation>();

            foreach (var book in books)
            {
                var bookInformation = _mapper.Map<BookInformation>(book);

                if (bookInformation is null)
                    throw new  NullReferenceException(nameof(bookInformation));

                bookInformation.Geners = book.BookGenres.Select(bg => bg.Genre.Name).ToList();

                bookInformations.Add(bookInformation);
            }
            
            return bookInformations;
        }
    }
}
