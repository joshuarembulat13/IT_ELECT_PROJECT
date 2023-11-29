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
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the booking.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                }
            }

            // If ModelState is not valid or an exception occurred, return to the form with validation or error messages
            return View("Booking", booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBooking(Booking updatedBooking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the most recent booking from the database
                    Booking existingBooking = _bookingService.GetMostRecentBooking();

                    if (existingBooking != null)
                    {
                        // Update the existing booking with the new values
                        existingBooking.FirstName = updatedBooking.FirstName;
                        existingBooking.LastName = updatedBooking.LastName;
                        existingBooking.Email = updatedBooking.Email;
                        existingBooking.Citizenship = updatedBooking.Citizenship; // Ensure this line is present
                        existingBooking.PhoneNumber = updatedBooking.PhoneNumber;

                        // Save the updated booking to the database
                        _bookingService.UpdateBooking(existingBooking);

                        // Pass the updated booking to a different view for display
                        return View("UpdatedBookingInfo", existingBooking);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "No existing booking found.");
                    }
                }
                catch (DbUpdateException ex)
                {
                    // Handle exceptions
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the booking.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                }
            }

            // If ModelState is not valid or an exception occurred, return to the form with validation or error messages
            return View("Booking", updatedBooking);
        }

    }
}
