using Microsoft.AspNetCore.Mvc;
using Modsen.Dto;
using Modsen.Services.Interfaces;

namespace Modsen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IApplicationAuthorizationService _authorizationService;

        public AuthorizationController(IApplicationAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(ApplicationUserLoginDto dto)
        {
            var result = await _authorizationService.LoginAsync(dto);

            if (result)
                return Ok(new
                {
                    token = _authorizationService.CreateJwtToken()
                });

            return new BadRequestObjectResult(result);
        }
    }
}
