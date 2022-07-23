﻿using techreads.Models;
using techreads.Services;
using Microsoft.AspNetCore.Mvc;

namespace techreads.Controllers;

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
        BookService.Add(book);
        return CreatedAtAction(nameof(Create), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        var existingPizza = BookService.Get(id);


        if (existingPizza is null) return NotFound();


        BookService.Update(book);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = BookService.Get(id);

        if (book is null) return NotFound();

        BookService.Delete(id);
        return NoContent();
    }
}