using ECommerce.Models.Dtos;
using ECommerce.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginDto());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return View(loginDto);
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user == null) return RedirectToAction(nameof(Login));
            var result = await _signInManager.PasswordSignInAsync(user,loginDto.Password, true, false);
            if (!result.Succeeded) return View(loginDto);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterDto());
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid) return View(registerDto);

            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                ModelState.AddModelError("Email", "The Email is Taken");
                return View(registerDto);
            }

            var user = new Models.Users.User()
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                RegisteredDate = DateTime.UtcNow,
                EmailConfirmed = true,

            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return View(registerDto);

            await _userManager.AddToRoleAsync(user, "Customer");

            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
