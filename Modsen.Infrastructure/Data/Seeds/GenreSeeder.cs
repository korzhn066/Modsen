using Microsoft.EntityFrameworkCore;
using Modsen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Infrastructure.Data.Seeds
{
    internal static class GenreSeeder
    {
        internal static void SeedGenres(this ModelBuilder builder)
        {
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
        }
    }
}
