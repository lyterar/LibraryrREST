using BookStore.Core.Models;
using BookStore.DataAccess.Repositories;

namespace BookStore.BL.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public Task<List<Comment>> GetCommentsByBookId(Guid bookId) =>
        _commentRepository.GetByBookIdAsync(bookId);

    public Task<Comment?> GetCommentById(Guid id) =>
        _commentRepository.GetByIdAsync(id);

    public Task<Guid> CreateComment(Comment comment) =>
        _commentRepository.CreateAsync(comment);

    public Task UpdateComment(Comment comment) =>
        _commentRepository.UpdateAsync(comment);

    public Task DeleteComment(Guid id) =>
        _commentRepository.DeleteAsync(id);
}