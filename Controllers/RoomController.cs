using Microsoft.AspNetCore.Mvc;



namespace Finals.Controllers
{
    public class RoomController : Controller
    {


        public IActionResult Room()
        {
            return View();
        }
    }
}