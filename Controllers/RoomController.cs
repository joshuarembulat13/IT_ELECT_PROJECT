using Microsoft.AspNetCore.Mvc;



namespace Finals.Controllers
{
    public class RoomController : Controller
    {


        public IActionResult Room()
        {
            return View();
        }
        public IActionResult StandardRoom()
        {
            // You can add any necessary logic here
            return View();
        }
        public IActionResult DeluxeRoom()
        {
            // You can add any necessary logic here
            return View();
        }
        public IActionResult SupremeRoom()
        {
            // You can add any necessary logic here
            return View();
        }
        public IActionResult FamilyRoom()
        {
            // You can add any necessary logic here
            return View();
        }
    }
}