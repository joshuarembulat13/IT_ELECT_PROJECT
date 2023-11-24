
using Microsoft.AspNetCore.Mvc;
using Finals.Models;

namespace Finals.Controllers;
public class DashboardController : Controller
{
    private readonly ILogger<DashboardController> _logger;

    public DashboardController(ILogger<DashboardController> logger)
    {
        _logger = logger;
    }
    public IActionResult Admin()
    {
        return View();
    }

    public IActionResult Booking()
    {
        return View();
    }
    public IActionResult Settings()
    {
        return View();
    }
}
