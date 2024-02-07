using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modsen.Application.Features.Book;
using Modsen.Application.Features.Book.Commands;
using Modsen.Application.Features.Book.Queries;
using System.Threading;

namespace Modsen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var book = await _mediator.Send(new GetBookById() { Id = id }, cancellationToken);

            return Ok(book);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(int page, int count, CancellationToken cancellationToken)
        {
            var books = await _mediator.Send(new GetAllBooks() { Page = page, Count = count}, cancellationToken);

            return Ok(books);
        }

        [HttpGet]
        [Route("GetByISBN")]
        public async Task<IActionResult> GetByISBN(string ISBN, CancellationToken cancellationToken)
        {
            var books = await _mediator.Send(new GetBookByISBN() { ISBN = ISBN }, cancellationToken);

            return Ok(books);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteBook() { Id = id }, cancellationToken);

            return NoContent();
        }

        [HttpPut]
        [Route("Add")]
        public async Task<IActionResult> Add(AddBook addBook, CancellationToken cancellationToken)
        {
            await _mediator.Send(addBook, cancellationToken);

            return NoContent();
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<IActionResult> Update(int Id, string Name, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateBook() { Id = Id, Name = Name }, cancellationToken);

            return NoContent();
        }
    }
}
