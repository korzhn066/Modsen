using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Modsen.Dto;
using Modsen.Entities;
using Modsen.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modsen.Services
{
    public class ApplicationAuthorizationService : IApplicationAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApplicationUser? _user;

        public ApplicationAuthorizationService(
            UserManager<ApplicationUser> userManager, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public string CreateJwtToken()
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user!.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> LoginAsync(ApplicationUserLoginDto dto)
        {
            _user = await _userManager.FindByNameAsync(dto.UserName);

            if (_user is null)
                return false;

            var result = await _userManager.CheckPasswordAsync(_user, dto.Password);

            return result;
        }
    }
}
