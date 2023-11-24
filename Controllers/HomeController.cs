using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Finals.Models;
using Microsoft.AspNetCore.Authorization;

namespace Finals.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("HomeController - Index action reached.");

        // Retrieve the username from the authentication context
        string username = User.Identity.IsAuthenticated ? User.Identity.Name : null;

        // Pass the username to the view
        ViewBag.Username = username;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Tracker()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
