using techreads.Models;
using techreads.Services;
using Microsoft.AspNetCore.Mvc;


namespace techreads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BookController : Controller
    {
        BookService BookSvc;

        public BookController()
        {
        }


        [HttpGet]
        public ActionResult<List<Book>> AllBooks() => BookSvc.GetAllBooks().ToList<Book>();

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = BookSvc.Get(id);

            if (book == null) return NotFound();

            return book;
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            BookSvc.Add(book);

            return CreatedAtAction(nameof(Create), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var existingBook = BookSvc.Get(id);

            if (existingBook is null) return NotFound();

            BookSvc.Update(book);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = BookSvc.Get(id);

            if (book is null) return NotFound();

            BookSvc.Delete(id);
            return NoContent();
        }
    }
}