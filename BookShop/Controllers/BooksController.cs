using BookShop.Data.Services;
using BookShop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService _bookService;
        public BooksController(BookService bookService)
        {
            this._bookService = bookService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var allBooks = _bookService.GetAll();
            return Ok(allBooks);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.getBook(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]BookVM book)
        {
           _bookService.AddBook(book);
           return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookVM book)
        {
            var result = _bookService.UpdateBook(id, book);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}