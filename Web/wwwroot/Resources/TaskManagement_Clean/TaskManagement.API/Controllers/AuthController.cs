using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TaskManagement.Application.Contracts.Requests;
using TaskManagement.Application.Contracts.Responses;
using TaskManagement.Infrastructure.Identity;

namespace TaskManagement.API.Controllers
{
    
    [ApiController]
    public class AuthController(ILogger<AuthController> logger, UserManager<ApplicationUser> UserManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly UserManager<ApplicationUser> _userManager = UserManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly ITokenService _tokenService = tokenService;

        [AllowAnonymous]
        [HttpPost(ApiEndpoints.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Email and password are required" });
            }

            var identityUser = await _userManager.FindByEmailAsync(request.Email);
            if (identityUser == null)
            {
                _logger.LogWarning("Login failed. No user found with email: {Email}", request.Email);
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var roles = await _userManager.GetRolesAsync(identityUser);
            var checkPassword = await _signInManager.CheckPasswordSignInAsync(identityUser, request.Password, lockoutOnFailure: true);

            if (checkPassword.Succeeded)
            {
                var jwtToken = _tokenService.GenerateJwtToken(identityUser, roles.ToList());
                var response = new LoginResponseDto
                {
                    Email = request.Email,
                    Roles = roles.ToList(),
                    Token = jwtToken
                };

                _logger.LogInformation("User {Email} logged in successfully.", request.Email);
                return Ok(response);
            }
            else
            {
                _logger.LogWarning("Invalid login attempt for {Email}", request.Email);
                return Unauthorized(new { message = "Invalid credentials" });
            }

        }
    }
}
