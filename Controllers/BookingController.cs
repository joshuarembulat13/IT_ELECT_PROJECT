using Finals.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Add this line
using Finals.Models;

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

        public ActionResult SaveUnverifiedBooking(UnverifiedBooking unverifiedBooking)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    // Save the booking to the database
                    _bookingService.SaveBooking(unverifiedBooking);

                    BookingID booking = new BookingID();
                    booking.Id = unverifiedBooking.Id;

                    // Pass the saved booking as the model when redirecting to the 'Booking' view
                    return View("Booking", CreateBookingTuple(booking, null));
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
            return View("Booking", CreateBookingTuple(null, null));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBooking(Bookings booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Save the booking to the database
                    _bookingService.SaveBooking(booking);

                    // Pass the saved booking as the model when redirecting to the 'Booking' view
                    return View("Booking", CreateBookingTuple(null, booking));
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
            return View("Booking", CreateBookingTuple(null, booking));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBooking(Bookings updatedBooking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Save the booking to the database
                    _bookingService.SaveBooking(updatedBooking);

                    // Pass the booking to a different view for display
                    return View("UpdatedBookingInfo", updatedBooking);
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
            return View("Booking", CreateBookingTuple(null, updatedBooking));
        }

        public (BookingID?, Bookings?) CreateBookingTuple(BookingID? bookingID, Bookings? booking) => (bookingID, booking);
    }
}
