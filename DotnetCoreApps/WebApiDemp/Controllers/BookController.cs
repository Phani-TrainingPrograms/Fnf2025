using BookAuthorApi.Core.DTOs;
using BookAuthorApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//API Controllers are similar to controllers of MVC applications, but they are specifically designed to handle HTTP requests and responses for RESTful APIs. They typically return data in formats like JSON or XML rather than rendering views.
namespace BookAuthorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository repo)
        {
            this._bookRepository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var model = books.Select(b => new BookDto(b.BookId,b.Title,
b.BookPrice, b.AuthorId));
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(new BookDto(book.BookId, book.Title, book.BookPrice, book.AuthorId));
        }
    }
}
