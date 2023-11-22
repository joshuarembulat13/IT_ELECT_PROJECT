

using Microsoft.AspNetCore.Mvc;

namespace Finals.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Booking()
        {
            return View();
        }
    }
}