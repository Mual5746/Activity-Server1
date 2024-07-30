using API.DTOs;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController :ControllerBase
    {
        private readonly UserManager<AppUser> _userMager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userMager = userManager;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login (LoginDto loginDto)
        {
            var user = await _userMager.FindByEmailAsync(loginDto.Email);
            if (user == null)   return Unauthorized();

            var result = await _userMager.CheckPasswordAsync(user, loginDto.Password);

            if (result)
            {
                return new UserDto 
                {
                    DisplayName = user.DisplayName,
                    Image = null,
                    Token = "This will be a token",
                    Username = user.UserName
                };
            }
            return Unauthorized();
        }

    }
}