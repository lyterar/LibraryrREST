using BookStore.Core.Models;
using BookStore.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookContentController : ControllerBase
{
    private readonly BookContentService _bookContentService;

    public BookContentController(BookContentService bookContentService)
    {
        _bookContentService = bookContentService;
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetByBookId(Guid bookId)
    {
        var content = await _bookContentService.GetContentByBookId(bookId);
        if (content == null)
            return NotFound();

        return Ok(content);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdate([FromBody] BookContent content)
    {
        var id = await _bookContentService.CreateOrUpdateContent(content);
        return Ok(id);
    }

    [HttpDelete("{bookId}")]
    public async Task<IActionResult> Delete(Guid bookId)
    {
        var result = await _bookContentService.DeleteContent(bookId);
        return result ? NoContent() : NotFound();
    }
}