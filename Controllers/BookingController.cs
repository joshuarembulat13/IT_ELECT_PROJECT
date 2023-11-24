using Finals.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Add this line

namespace Finals.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Save the booking to the database
                    _bookingService.SaveBooking(booking);

                    // Pass the saved booking as the model when redirecting to the 'Booking' view
                    return View("Booking", booking);
                }
                catch (DbUpdateException ex)
                {
                    // Handle exceptions
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                }
            }

            // If ModelState is not valid, return to the form with validation errors
            return View("Booking");
        }






    }
}
