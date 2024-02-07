using Microsoft.EntityFrameworkCore;
using Modsen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Infrastructure.Data.Seeds
{
    internal static class BookGenreSeeder
    {
        internal static void SeedBookGenres(this ModelBuilder builder)
        {
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
        }
    }
}
