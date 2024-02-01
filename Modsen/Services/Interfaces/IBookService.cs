using Modsen.Dto;

namespace Modsen.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookInformationDto>> GetAllBooksAsync();
        Task<BookInformationDto> GetBookByIdAsync(int id);
        Task<BookInformationDto> GetBookByISBNAsync(string ISBN);
        Task AddBookAsync(AddBookDto addBookDto);
        Task UpdateBookAsync(UpdateBookDto updateBookDto);
        Task DeleteBookAsync(int id);
    }
}
