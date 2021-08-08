using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Movies.React.Models;
using Movies.Core.Models;
using Movies.Core.Service.Interfaces;

namespace Movies.React.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _config;
        private IUserService _userService;

        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration config,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _userService = userService;
        }

        [AllowAnonymous, HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticateModel authenticateModel)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(authenticateModel.Username, authenticateModel.Password, isPersistent: false, lockoutOnFailure: false);

            if (!loginResult.Succeeded)
            {
                return Unauthorized();
            }

            var user = await _userManager.FindByNameAsync(authenticateModel.Username);

            return Ok(new { Token = _userService.GetToken(user), User = user });
        }
    }
}
