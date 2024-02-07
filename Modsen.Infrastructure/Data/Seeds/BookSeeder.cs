using Microsoft.EntityFrameworkCore;
using Modsen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Infrastructure.Data.Seeds
{
    internal static class BookSeeder
    {
        internal static void SeedBooks(this ModelBuilder builder)
        {
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
        }
    }
}
