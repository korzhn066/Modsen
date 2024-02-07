using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Modsen.Domain.Entities;
using Modsen.Domain.Models;
using Modsen.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Application.Services
{
    public class ApplicationAuthenticationService : IApplicationAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ApplicationAuthenticationService(
            UserManager<ApplicationUser> userManager,
            IMapper mapper) 
        { 
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<bool> LoginAsync(Authentication authentication)
        {
            var user = await _userManager.FindByNameAsync(authentication.UserName);

            if (user is null)
                return false;

            var result = await _userManager.CheckPasswordAsync(user, authentication.Password);

            return result;
        }

        public async Task<IdentityResult> RegisterAsync(Authentication authentication)
        {
            var user = _mapper.Map<ApplicationUser>(authentication);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = await _userManager.CreateAsync(user, authentication.Password);

            return result;
        }
    }
}
