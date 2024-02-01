using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modsen.Dto;
using Modsen.Services.Interfaces;

namespace Modsen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await _bookService.GetBookByIdAsync(id);

            return Ok(books);
        }

        [HttpGet]
        [Route("GetByISBN")]
        public async Task<IActionResult> GetByISBN(string ISBN)
        {
            var books = await _bookService.GetBookByISBNAsync(ISBN);

            return Ok(books);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task Add(AddBookDto addBookDto)
        {
            await _bookService.AddBookAsync(addBookDto);
        }

        [HttpPost]
        [Route("Update")]
        public async Task Update(UpdateBookDto addBookDto)
        {
            await _bookService.UpdateBookAsync(addBookDto);
        }
    }
}
