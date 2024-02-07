using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modsen.Domain.Models;
using Modsen.Domain.Services;

namespace Modsen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IApplicationAuthenticationService _authenticationService;
        private readonly ITokenProviderService _tokenProviderService;

        public AuthenticationController(
            IApplicationAuthenticationService authenticationService,
            ITokenProviderService tokenProviderService)
        {
            _authenticationService = authenticationService;
            _tokenProviderService = tokenProviderService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Authentication authentication)
        {
            var result = await _authenticationService.LoginAsync(authentication);

            if (result)
                return Ok(new
                {
                    token = _tokenProviderService.CreateJwtToken()
                });

            return new BadRequestObjectResult(result);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Authentication authentication)
        {
            var result = await _authenticationService.RegisterAsync(authentication);

            if (result.Succeeded)
                return Ok(new
                {
                    token = _tokenProviderService.CreateJwtToken()
                });

            return new BadRequestObjectResult(result);
        }
    }
}
