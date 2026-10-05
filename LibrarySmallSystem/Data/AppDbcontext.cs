using LibrarySmallSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace LibrarySmallSystem.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Borrowing> borrowings { get; set; }
        public DbSet<Member> members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(b => b.Books)
                .WithOne(c => c.Category)
                .HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Member>()
                .HasMany(b => b.Borrowings)
                .WithOne(m => m.Member)
                .HasForeignKey(b => b.MemberId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Borrowings)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Category>().HasData
                (
                new Category { Id = 1, Name = "Fiction", Description = "Fictional books" },
                new Category { Id = 2, Name = "Non-Fiction", Description = "Non-Fictional books" },
                new Category { Id = 3, Name = "Science", Description = "Scientific books" },
                new Category { Id = 4, Name = "History", Description = "Historical books" }


                );


            modelBuilder.Entity<Book>().HasData
            (
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", CategoryId = 1 ,ISBN= "SBN001" },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", CategoryId = 1 ,ISBN= "ISBN002" }


                );


            modelBuilder.Entity<Member>().HasData
                (
                    new Member
                    {
                        Id = 1,
                        Name = "John Doe",
                        Email = "ahmed@example.com",
                        Phone = "1234567890"

                    },
                    new Member
                    {
                        Id = 2,
                        Name = "Jane Smith",
                        Email = "sara@example.com",
                        Phone = "0987654321"
                    }


                );

            modelBuilder.Entity<Borrowing>().HasData
                (
                new Borrowing
                {
                    Id = 1,
                    BorrowedDate = new DateTime(2026 - 09 - 22),
                    ReturnedDate = null,
                    MemberId = 1,
                    BookId = 1
                },
                new Borrowing
                {
                    Id = 2,
                    BorrowedDate = new DateTime(2026 - 09 - 20),
                    ReturnedDate = null,
                    MemberId = 2,
                    BookId = 2
                }


                );

        }
    }
}
