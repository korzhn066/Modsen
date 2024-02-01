using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modsen.Data;
using Modsen.Dto;
using Modsen.Entities;
using Modsen.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Modsen.Services
{
    public class BookService : IBookService
    {
        private readonly DBContext _dbContext;
        private readonly IMapper _mapper;

        public BookService(
            DBContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddBookAsync(AddBookDto addBookDto)
        {
            var book = _mapper.Map<Book>(addBookDto);

            var bookGeners = new List<BookGenre>();
            foreach(var generId in addBookDto.GenresId)
            {
                var genre = await _dbContext.Genres.FindAsync(generId);

                if (genre is null)
                    throw new ArgumentException("Gener with this id does not exist");

                bookGeners.Add(new BookGenre()
                {
                    GenreId = generId,
                });
            }

            book.BookGenres = bookGeners;

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = new Book() { Id = id };
            _dbContext.Books.Remove(book);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BookInformationDto>> GetAllBooksAsync()
        {
            var books = await _dbContext.Books
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .ToListAsync();

            var bookInformations = new List<BookInformationDto>();

            foreach (var book in books)
            {
                var geners = new List<string>();

                foreach(var bookGener in book.BookGenres)
                {
                    geners.Add(bookGener.Genre.Name);
                }

                var bookInformation = _mapper.Map<BookInformationDto>(book);
                bookInformation.Geners = geners;
                bookInformations.Add(bookInformation);
            }

            return bookInformations;
        }

        public async Task<BookInformationDto> GetBookByIdAsync(int id)
        {
            var book = await _dbContext.Books
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book is null)
                throw new ArgumentException("book with this id does not exist");

            var geners = new List<string>();

            foreach (var bookGener in book.BookGenres)
            {
                geners.Add(bookGener.Genre.Name);
            }

            var bookInformation = _mapper.Map<BookInformationDto>(book);
            bookInformation.Geners = geners;

            return bookInformation;
        }

        public async Task<BookInformationDto> GetBookByISBNAsync(string ISBN)
        {
            var book = await _dbContext.Books
               .Include(b => b.BookGenres)
               .ThenInclude(bg => bg.Genre)
               .FirstOrDefaultAsync(b => b.ISBN == ISBN);

            if (book is null)
                throw new ArgumentException("book with this ISBN does not exist");

            var geners = new List<string>();

            foreach (var bookGener in book.BookGenres)
            {
                geners.Add(bookGener.Genre.Name);
            }

            var bookInformation = _mapper.Map<BookInformationDto>(book);
            bookInformation.Geners = geners;

            return bookInformation;
        }

        public async Task UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var book = await _dbContext.Books
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(b => b.Id == updateBookDto.Id);

            if (book is null)
                throw new ArgumentException("book with this id does not exist");

            book.ISBN = updateBookDto.ISBN;
            book.Name = updateBookDto.Name;
            book.Author = updateBookDto.Author;
            book.Description = updateBookDto.Description;
            book.Taken = updateBookDto.Taken;
            book.Returned = updateBookDto.Returned;

            var bookGeners = new List<BookGenre>();
            foreach (var generId in updateBookDto.GenresId)
            {
                var isCollision = false;
                foreach (var bookGener in book.BookGenres)
                {
                    if (generId == bookGener.GenreId)
                    {
                        bookGeners.Add(bookGener);
                        isCollision = true;
                        break;
                    }
                }

                if (isCollision)
                    continue;

                var genre = await _dbContext.Genres.FindAsync(generId);

                if (genre is null)
                    throw new ArgumentException("Gener with this id does not exist");

                bookGeners.Add(new BookGenre()
                {
                    GenreId = generId,
                });
            }

            book.BookGenres = bookGeners;

            await _dbContext.SaveChangesAsync();
        }
    }
}
