using Microsoft.AspNetCore.Identity;
using Modsen.Dto;

namespace Modsen.Services.Interfaces
{
    public interface IApplicationAuthorizationService
    {
        string CreateJwtToken();
        Task<bool> LoginAsync(ApplicationUserLoginDto dto);
    }
}
