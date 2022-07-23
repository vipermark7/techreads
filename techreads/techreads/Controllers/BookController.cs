using techreads.Models;
using techreads.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    public BookController()
    {
    }


    [HttpGet]
    public ActionResult<List<Book>> GetAll() => BookService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = BookService.Get(id);


        if (book == null) return NotFound();


        return book;
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        // The IActionResult will return the request's status and the id of the newly created book
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
    {
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
    }
}