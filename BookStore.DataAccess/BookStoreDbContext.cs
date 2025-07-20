using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    // 🔹 Таблицы
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<AuthorBookEntity> AuthorBooks { get; set; }
    public DbSet<BookContentEntity> BookContents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 🔸 One-to-One: Book ↔ BookContent
        modelBuilder.Entity<BookContentEntity>()
            .HasKey(bc => bc.BookId);

        modelBuilder.Entity<BookContentEntity>()
            .HasOne(bc => bc.Book)
            .WithOne(b => b.BookContent)
            .HasForeignKey<BookContentEntity>(bc => bc.BookId);

        // 🔸 Many-to-Many: Book ↔ Author (через AuthorBookEntity)
        modelBuilder.Entity<AuthorBookEntity>()
            .HasKey(ab => new { ab.AuthorId, ab.BookId });

        modelBuilder.Entity<AuthorBookEntity>()
            .HasOne(ab => ab.Author)
            .WithMany(a => a.AuthorBooks)
            .HasForeignKey(ab => ab.AuthorId);

        modelBuilder.Entity<AuthorBookEntity>()
            .HasOne(ab => ab.Book)
            .WithMany(b => b.AuthorBooks)
            .HasForeignKey(ab => ab.BookId);

        // 🔸 Comment: self-referencing (ответы на комментарии)
        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict); // запретить каскадное удаление

        // 🔸 Book → Comment
        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.Book)
            .WithMany(b => b.Comments)
            .HasForeignKey(c => c.BookId);

        // 🔸 User → Comment
        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        // 🔸 User → Order
        modelBuilder.Entity<OrderEntity>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        // 🔸 OrderItem → Order
        modelBuilder.Entity<OrderItemEntity>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId);

        // 🔸 OrderItem → Book
        modelBuilder.Entity<OrderItemEntity>()
            .HasOne(oi => oi.Book)
            .WithMany(b => b.OrderItems)
            .HasForeignKey(oi => oi.BookId);
    }
}
