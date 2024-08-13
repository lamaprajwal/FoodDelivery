using FoodDelivery.Models;
using FoodDelivery.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Unauthorized(new { Message = "Login failed. Invalid email or password." });
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return Unauthorized();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel rvm )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user=new IdentityUser
            { UserName = rvm.Name,
            Email = rvm.Email,
            PhoneNumber=rvm.Phone,
           };
            var result = await _userManager.CreateAsync(user, rvm.Password);
            if (result.Succeeded) 
            {
                await _signInManager.SignInAsync(user, false);
            }
            return Ok(result);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
