using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Finals.data;
using Microsoft.AspNetCore.Authorization;

namespace Finals.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext dbContext, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (model == null || string.IsNullOrEmpty(model.DisplayName))
            {
                ViewBag.ErrorMessage = "Username cannot be null or empty.";
                return View();
            }

            var existingUser = await _userManager.FindByNameAsync(model.DisplayName);
            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "Username is already taken. Please choose a different one.";
                return View();
            }

            var result = await _userManager.CreateAsync(new User
            {
                DisplayName = model.DisplayName,
                UserName = model.DisplayName,
                PasswordHash = _userManager.PasswordHasher.HashPassword(null, model.PasswordHash)
            });

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (model == null || string.IsNullOrEmpty(model.DisplayName))
            {
                ViewBag.ErrorMessage = "Please provide a valid username.";
                return View();
            }

            var user = await _userManager.FindByNameAsync(model.DisplayName);

            if (user != null)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Log successful login
                _logger.LogInformation($"User {user.DisplayName} authenticated: {User.Identity.IsAuthenticated}");

                // Redirect to the index page after successful login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }

        }



        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            // Redirect to the login page after logout
            return RedirectToAction("Login");
        }




    }
}
