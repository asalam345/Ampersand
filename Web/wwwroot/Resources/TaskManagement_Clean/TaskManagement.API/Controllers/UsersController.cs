using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.DTOs.Users;
using TaskManagement.Infrastructure.Identity;

namespace TaskManagement.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost(ApiEndpoints.Users.Create)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = Activator.CreateInstance<ApplicationUser>();
            user.UserName = createUserDto.UserName;
            user.Email = createUserDto.Email;
            user.FullName = createUserDto.FullName;
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _userManager.AddToRoleAsync(user, createUserDto.Role);
            return Ok(new { user.Id, user.UserName, user.Email, user.FullName });
        }
        [Authorize(Roles = "Admin")]
        [HttpGet(ApiEndpoints.Users.GetAll)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.Select(u => new { u.Id, u.UserName, u.Email, u.FullName }).OrderByDescending(x=>x.Id).ToListAsync();
            return Ok(users);
        }
    }
}
