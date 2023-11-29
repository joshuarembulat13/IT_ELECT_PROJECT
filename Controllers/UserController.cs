// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Identity;
// using System.Threading.Tasks;
// using Finals.data;
// using Microsoft.AspNetCore.Authorization;

// namespace Finals.Controllers
// {
//     public class UserController : Controller
//     {
//         private readonly UserManager<User> _userManager;
//         private readonly SignInManager<User> _signInManager;
//         private readonly ApplicationDbContext _dbContext;
//         private readonly ILogger<UserController> _logger;

//         public UserController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext dbContext, ILogger<UserController> logger)
//         {
//             new User { Email = "user1", Password = "password1" };
//             new User { Email = "user2", Password = "password2" };
//         }

//         // _userManager = userManager;
//         //     _signInManager = signInManager;
//         //     _dbContext = dbContext;
//         //     _logger = logger;

//         public IActionResult Login()
//         {
//             return View();
//         }

//         [HttpPost]
//         public IActionResult Register(User model)
//         {
//             // Check if the Email is already taken
//             if (_users.Any(u => u.Email == model.Email))
//             {
//                 ViewBag.ErrorMessage = "Email is already taken. Please choose a different one.";
//                 return View();
//             }

//             // Add the new user to the list
//             _users.Add(model);

//             // You can add authentication logic here if needed

//             // Redirect to the login page after successful registration
//             return RedirectToAction("Login");
//             public ActionResult Register()
//             {
//                 return View();
//             }

//             [HttpPost]
//             public async Task<IActionResult> Register(User model)
//             {
//                 var user = _users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
//                 if (model == null || string.IsNullOrEmpty(model.DisplayName))
//                 {
//                     ViewBag.ErrorMessage = "Username cannot be null or empty.";
//                     return View();
//                 }

//                 // Check if the username is already taken
//                 var existingUser = await _userManager.FindByNameAsync(model.DisplayName);
//                 if (existingUser != null)
//                 {
//                     TempData["ErrorMessage"] = "Username is already taken. Please choose a different one.";
//                     return View();
//                 }

//                 if (model == null || string.IsNullOrEmpty(model.Email))
//                 {
//                     ViewBag.ErrorMessage = "Email cannot be null or empty.";
//                     return View();
//                 }

//                 // Check if the email is already associated with an existing account
//                 var existingEmail = await _userManager.FindByEmailAsync(model.Email);
//                 if (existingEmail != null)
//                 {
//                     TempData["ErrorMessageB"] = "Email is already associated with an existing account. Please use a different email.";
//                     return View();
//                 }

//                 // Continue with the registration process
//                 var result = await _userManager.CreateAsync(new User
//                 {
//                     DisplayName = model.DisplayName,
//                     UserName = model.DisplayName,
//                     Email = model.Email, // Ensure this line is present
//                     PasswordHash = _userManager.PasswordHasher.HashPassword(null, model.PasswordHash)
//                 });

//                 if (result.Succeeded)
//                 {
//                     return RedirectToAction("Login");
//                 }
//                 else
//                 {
//                     foreach (var error in result.Errors)
//                     {
//                         ModelState.AddModelError(string.Empty, error.Description);
//                     }

//                     return View();
//                 }
//             }


//             [AllowAnonymous]
//             [HttpPost]
//             public async Task<IActionResult> Login(User model)
//             {
//                 if (model == null || string.IsNullOrEmpty(model.DisplayName))
//                 {
//                     ViewBag.ErrorMessage = "Please provide a valid username.";
//                     return View();
//                 }

//                 var user = await _userManager.FindByNameAsync(model.DisplayName);

//                 if (user != null)
//                 {
//                     await _signInManager.SignInAsync(user, isPersistent: false);

//                     // Log successful login
//                     _logger.LogInformation($"User {user.DisplayName} authenticated: {User.Identity.IsAuthenticated}");

//                     // Redirect to the index page after successful login
//                     return RedirectToAction("Index", "Home");
//                 }
//                 else
//                 {
//                     ViewBag.ErrorMessage = "Invalid username or password";
//                     return View();
//                 }

//             }


//             public async Task<IActionResult> Logout()
//             {
//                 await _signInManager.SignOutAsync();

//                 // Redirect to the login page after logout
//                 return RedirectToAction("Login");
//             }



//             public IActionResult StandardRoom()
//             {
//                 return View();
//             }


//         }
//     }

// }
