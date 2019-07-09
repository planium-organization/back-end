using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core.DTOs.Shared;
using KP.BackEnd.Core.DTOs.Shared.UserManagement;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Shared.Controllers
{
    [ApiController, Route("api/shared/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var roleExists = await _roleManager.RoleExistsAsync(registerDto.Role);
            if (!roleExists)
                return BadRequest("Role doesn't exist");
            
            var newUser = new ApplicationUser(registerDto.Username)
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var creationResult = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!creationResult.Succeeded)
                return BadRequest(creationResult.Errors.Select(error => error.Description).Aggregate((errorDescriptions, identityError) => errorDescriptions + $", {identityError}"));

            var roleResult = await _userManager.AddToRoleAsync(newUser, registerDto.Role);
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors.Select(error => error.Description).Aggregate((errorDescriptions, identityError) => errorDescriptions + $", {identityError}"));
                
            return NoContent();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return BadRequest("Login failed");

            var signInResult = await _signInManager.PasswordSignInAsync(user, loginDto.Password, isPersistent: true, lockoutOnFailure: false); //lockout on failure is off because this is a demo

            if (!signInResult.Succeeded)
                return BadRequest("Login failed");

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }

    }
}