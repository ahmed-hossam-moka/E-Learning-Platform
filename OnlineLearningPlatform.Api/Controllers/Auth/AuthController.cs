using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineLearningPlatform.DAL.Models;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.BLL.Dtos.Auth;
using OnlineLearningPlatform.BLL.Managers.Auth;

namespace OnlineLearningPlatform.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authManager.Login(loginDto);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(new { email = result.Email, role = result.Role,
                           token = result.Token, expireOn = result.ExpiresOn });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authManager.Register(registerDto);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(new { email = result.Email, role = result.Role, token = result.Token, expireOn = result.ExpiresOn });
        }

    }
}