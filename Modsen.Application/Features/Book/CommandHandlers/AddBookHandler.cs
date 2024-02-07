using AutoMapper;
using MediatR;
using Modsen.Application.Features.Book.Commands;
using Modsen.Domain.Entities;
using Modsen.Domain.Repositories;

namespace Modsen.Application.Features.Book.CommandHandlers
{
    internal class AddBookHandler : IRequestHandler<AddBook>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;

        private readonly IMapper _mapper;
        public AddBookHandler(
            IBookRepository bookRepository,
            IGenreRepository genreRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task Handle(AddBook request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Domain.Entities.Book>(request);

            if (book is null)
                throw new ArgumentNullException(nameof(book));

            var bookGeners = new List<BookGenre>();
            foreach (var generId in request.GenersId)
            {
                var genre = await _genreRepository.GetByIdAsync(generId, cancellationToken);

                if (genre is null)
                    throw new ArgumentException("Gener with this id does not exist");

                bookGeners.Add(new BookGenre()
                {
                    GenreId = generId,
                });
            }

            book.BookGenres = bookGeners;

            await _bookRepository.AddAsync(book, cancellationToken);
            await _bookRepository.SaveChangesAsync();
        }
    }
}
