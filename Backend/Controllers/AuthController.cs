using Backend.DTOs;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        //POST: /api/Auth/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Username
            };
            var result = await _userManager.CreateAsync(identityUser, registerDto.Password);

            if (result.Succeeded)
            {
                if (registerDto.Roles != null && registerDto.Roles.Any())
                {
                    result = await _userManager.AddToRolesAsync(identityUser, registerDto.Roles ?? Array.Empty<string>());
                    if (result.Succeeded)
                    {
                        return Ok("User successfully registred");
                    }
                }
            }
            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles == null || !roles.Any())
                {
                    return Unauthorized("User has no roles assigned");
                }
                var token = _tokenRepository.CreateJWTToken(user, roles);
                var response = new LoginResponseDto
                {
                    Token = token
                };
                
                return Ok(response);
            }
            return Unauthorized("Invalid username or password");
        }
    }
}
