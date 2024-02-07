using Microsoft.AspNetCore.Identity;
using Modsen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Domain.Services
{
    public interface IApplicationAuthenticationService
    {
        Task<bool> LoginAsync(Authentication authentication);
        Task<IdentityResult> RegisterAsync(Authentication authentication);
    }
}
