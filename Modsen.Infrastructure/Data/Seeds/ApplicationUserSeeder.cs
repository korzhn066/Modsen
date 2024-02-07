using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modsen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Infrastructure.Data.Seeds
{
    internal static class ApplicationUserSeeder
    {
        internal static void SeedApplicationUsers(this ModelBuilder builder)
        {
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
        }
    }
}
