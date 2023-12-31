using System.Diagnostics;
using Finals.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Finals.Controllers;
public class DashboardController : Controller
{
    private readonly ILogger<DashboardController> _logger;


    private readonly ApplicationDbContext mssql;

    public DashboardController(ApplicationDbContext dummayData)
    {
        mssql = dummayData;
    }

    public IActionResult Admin()
    {
        ViewBag.BookingList = mssql.Bookings.ToList();

        return View("Admin", ViewBag.BookingList);
    }

    public IActionResult Booking()
    {
        return View();
    }
    public IActionResult Settings()
    {
        return View();
    }
    public IActionResult Archive()
    {

        return View("Archive", ViewBag.BookingList);
    }
}
