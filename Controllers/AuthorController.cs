using BookStore.Core.Models;
using BookStore.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _authorService;

    public AuthorController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _authorService.GetAllAuthors();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var author = await _authorService.GetAuthorById(id);
        if (author == null)
            return NotFound();

        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Author author)
    {
        var id = await _authorService.CreateAuthor(author);
        return CreatedAtAction(nameof(GetById), new { id }, author);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Author author)
    {
        if (id != author.Id)
            return BadRequest("Mismatched author ID");

        await _authorService.UpdateAuthor(author);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _authorService.DeleteAuthor(id);
        return NoContent();
    }
}