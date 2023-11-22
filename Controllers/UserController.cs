using Microsoft.AspNetCore.Mvc;

namespace Finals.Controllers
{
    public class UserController : Controller
    {
        private static List<User> _users = new List<User>
    {
        new User { Username = "user1", Password = "password1" },
        new User { Username = "user2", Password = "password2" }
    };

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var user = _users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

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
