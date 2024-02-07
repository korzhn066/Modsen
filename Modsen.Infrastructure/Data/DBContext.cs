using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modsen.Domain.Entities;
using Modsen.Infrastructure.Data.EntityConfigurations;
using Modsen.Infrastructure.Data.Seeds;

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
            builder.ConfigureBookGenre();

            builder.SeedBooks();
            builder.SeedGenres();
            builder.SeedBookGenres();
            builder.SeedApplicationUsers();

            base.OnModelCreating(builder);
        }
    }
}
