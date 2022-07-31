using System.Configuration;
using techreads.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace techreads.Services;

public class BookService
{
    private BookContext BookCtx;

    public BookService(BookContext db)
    {
        BookCtx = db;
    }

    public List<Book> GetAllBooks() => new();

    public Book? Get(int id) => GetAllBooks().FirstOrDefault(p => p.Id == id);

    public EntityEntry Add(Book book) => BookCtx.Books.Add(book);

    public  void Delete(int id)
    {
        var book = Get(id);
        if(book is null)
            return;

        BookCtx.Remove(book);
    }

    public void Update(Book book)
    {
        var index = GetAllBooks().FindIndex(p => p.Id == book.Id);
        if(index == -1)
            return;

        GetAllBooks()[index] = book;
    }

    public string GetCoverImage()
    {
        // first retrieve ISBN
        return "";
    }
}