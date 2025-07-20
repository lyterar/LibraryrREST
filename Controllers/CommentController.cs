using BookStore.Core.Models;
using BookStore.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("book/{bookId}")]
    public async Task<IActionResult> GetByBookId(Guid bookId)
    {
        var comments = await _commentService.GetCommentsByBookId(bookId);
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var comment = await _commentService.GetCommentById(id);
        if (comment == null)
            return NotFound();

        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Comment comment)
    {
        var id = await _commentService.CreateComment(comment);
        return CreatedAtAction(nameof(GetById), new { id }, comment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Comment comment)
    {
        if (id != comment.Id)
            return BadRequest("Mismatched comment ID");

        await _commentService.UpdateComment(comment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _commentService.DeleteComment(id);
        return NoContent();
    }
}