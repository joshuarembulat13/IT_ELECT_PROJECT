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
    }
}