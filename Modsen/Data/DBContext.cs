using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modsen.Entities;

namespace Modsen.Data
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DBContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            builder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);

            builder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            builder.Entity<Book>()
                .HasData
                (
                    new Book()
                    {
                        Id = 1,
                        ISBN = "978-5-699-12014-7",
                        Name = "Harry Poter",
                        Description = "Description",
                        Author = "Joanne Kathleen Rowling",
                        Taken = new DateTime(2023, 10, 2),
                        Returned = new DateTime(2023, 11, 2)
                    },
                    new Book()
                    {
                        Id = 2,
                        ISBN = "878-5-699-12014-7",
                        Name = "The Hunger Games",
                        Description = "Description",
                        Author = "Susan Collins",
                        Taken = new DateTime(2023, 10, 2),
                        Returned = new DateTime(2023, 11, 2)
                    },
                    new Book()
                    {
                        Id = 3,
                        ISBN = "973-5-699-12014-7",
                        Name = "The Witcher",
                        Description = "Description",
                        Author = "Andrzej Sapkowski",
                        Taken = new DateTime(2023, 10, 2),
                        Returned = new DateTime(2023, 11, 2)
                    }
                );

            builder.Entity<Genre>()
                .HasData
                (
                    new Genre()
                    {
                        Id = 1,
                        Name = "Horror"
                    },
                    new Genre()
                    {
                        Id = 2,
                        Name = "Fantasy"
                    }
                );

            builder.Entity<BookGenre>()
                .HasData
                (
                    new BookGenre()
                    {
                        BookId = 1,
                        GenreId = 2,
                    },
                    new BookGenre()
                    {
                        BookId = 2,
                        GenreId = 2,
                    },
                    new BookGenre()
                    {
                        BookId = 3,
                        GenreId = 2,
                    },
                    new BookGenre()
                    {
                        BookId = 2,
                        GenreId = 1,
                    }
                );

            var applicationUser = new ApplicationUser()
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                UserName = "user",
                NormalizedUserName = "USER".ToUpper(),
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "user");

            builder.Entity<ApplicationUser>()
                .HasData(applicationUser);

            base.OnModelCreating(builder);
        }
    }
}
