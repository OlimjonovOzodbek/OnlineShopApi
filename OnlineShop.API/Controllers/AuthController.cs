using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Abstractions;
using OnlineShop.Domain.Entities.Models;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<ActionResult<Tokenn>> Login([FromForm]RequestLogin model)
        {
            var result = await _authService.GenerateToken(model);

            return Ok(result);
        }
    }
}
