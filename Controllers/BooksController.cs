using BookStore.BL.Services;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[ApiController]
[Route("[controller]")]

public class BooksController: ControllerBase
{
private readonly IBookService _bookService;
public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllBooks()
    {
        return await _bookService.GetAllBooks();
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBook(Book book)
    {
        return await _bookService.CreateBook(book);
    }
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateBook(Guid id, string title, string description, decimal price)
    {
        return await _bookService.UpdateBook(id, title, description, price);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteBook(Guid id)
    {
        return await _bookService.DeleteBook(id);
    }
}