using Microsoft.AspNetCore.Mvc;

namespace Finals.Controllers
{
    public class ProfileController : Controller
    {


        public IActionResult Profile()
        {
            return View();
        }
    }
}