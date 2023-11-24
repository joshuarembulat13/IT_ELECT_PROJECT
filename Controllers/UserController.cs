using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.Diagnostics;

namespace Finals.Controllers
{
    public class UserController : Controller

    {

        private static List<User> _users = new List<User>
        {
            new User { Email = "user1", Password = "password1" },
            new User { Email = "user2", Password = "password2" }
        };

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            // Check if the Email is already taken
            if (_users.Any(u => u.Email == model.Email))
            {
                ViewBag.ErrorMessage = "Email is already taken. Please choose a different one.";
                return View();
            }

            // Add the new user to the list
            _users.Add(model);

            // You can add authentication logic here if needed

            // Redirect to the login page after successful registration
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var user = _users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                // Authentication successful
                // You can add authentication logic here (e.g., Forms Authentication, Identity, etc.)
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Authentication failed
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }
    }
}
