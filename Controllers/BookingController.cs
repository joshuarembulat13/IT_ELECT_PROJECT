using Finals.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Add this line
using Finals.Models;
using System.ComponentModel.DataAnnotations;

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
            if (ModelState.IsValid)
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
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(updatedBooking.PhoneNumber) || !IsNumeric(updatedBooking.PhoneNumber) || updatedBooking.PhoneNumber.Length != 11 || !updatedBooking.PhoneNumber.StartsWith("09"))
                    {
                        TempData["ErrorMessageD"] = "Not a valid Phone Number!";
                        return View("Booking", CreateBookingTuple(null, updatedBooking));
                    }


                    if (string.IsNullOrEmpty(updatedBooking.Email) || !new EmailAddressAttribute().IsValid(updatedBooking.Email))
                    {
                        TempData["ErrorMessageE"] = "Invalid Email Address.";
                        return View("Booking", CreateBookingTuple(null, updatedBooking));
                    }

                    if (string.IsNullOrEmpty(updatedBooking.FirstName) || updatedBooking.FirstName.Any(char.IsDigit))
                    {
                        TempData["ErrorMessageF"] = "Invalid First Name";
                        return View("Booking", CreateBookingTuple(null, updatedBooking));
                    }

                    if (string.IsNullOrEmpty(updatedBooking.LastName) || updatedBooking.LastName.Any(char.IsDigit))
                    {
                        TempData["ErrorMessageG"] = "Invalid Last Name";
                        return View("Booking", CreateBookingTuple(null, updatedBooking));
                    }

                    if (string.IsNullOrEmpty(updatedBooking.Citizenship) || updatedBooking.Citizenship.Any(char.IsDigit))
                    {
                        TempData["ErrorMessageH"] = "Invalid Citizenship";
                        return View("Booking", CreateBookingTuple(null, updatedBooking));
                    }


                    // Save the booking to the database
                    _bookingService.SaveBooking(updatedBooking);

                    // Pass the booking to a different view for display
                    return View("UpdatedBookingInfo", updatedBooking);
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

            // If ModelState is not valid or an exception occurred, return to the form with validation or error messages
            return View("Booking", CreateBookingTuple(null, updatedBooking));
        }

        // Helper method to check if a string is numeric
        private bool IsNumeric(string value)
        {
            return long.TryParse(value, out _);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBookingStatus(int bookingId, int status)
        {
            var booking = _bookingService.GetBookingById(bookingId);

            if (booking == null)
            {
                return NotFound(); // Return appropriate status if booking is not found
            }

            try
            {
                // Update the booking status based on the provided status value
                switch (status)
                {
                    case 1:
                        booking.BookingStatus = Status.Paid;
                        break;
                    case 0:
                        booking.BookingStatus = Status.Pending;
                        break;
                    case 2:
                        booking.BookingStatus = Status.Cancelled;
                        break;
                    // Add more cases for other status values if needed
                    default:
                        // Handle invalid status values
                        ModelState.AddModelError(string.Empty, "Invalid status value.");
                        return View("~/Views/Dashboard/Booking.cshtml", CreateBookingTuple(null, booking));
                }

                // Save the updated booking to the database
                _bookingService.UpdateBooking(booking);

                // Redirect to the 'Booking' view or any other view as needed
                return View("~/Views/Dashboard/Booking.cshtml", CreateBookingTuple(null, booking));
            }
            catch (DbUpdateException ex)
            {
                // Handle exceptions
                ModelState.AddModelError(string.Empty, "An error occurred while updating the booking status.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
            }

            // If ModelState is not valid or an exception occurred, return to the 'Booking' view with validation or error messages
            return View("Booking", CreateBookingTuple(null, booking));
        }


        [HttpPost]
        public IActionResult UpdateArchiveStatus(int bookingId)
        {
            // Get the booking from the database
            var booking = _bookingService.GetBookingById(bookingId);

            if (booking == null)
            {
                // Handle the case where the booking is not found
                return NotFound();
            }

            // Toggle the ArchiveStatus (change true to false and vice versa)
            booking.ArchiveStatus = !booking.ArchiveStatus;

            try
            {
                // Save changes to the database
                _bookingService.UpdateBooking(booking);

                // Redirect back to the 'Booking' view
                return View("~/Views/Dashboard/Booking.cshtml", CreateBookingTuple(null, booking));
            }
            catch (DbUpdateException ex)
            {
                // Handle exceptions
                ModelState.AddModelError(string.Empty, "An error occurred while updating the ArchiveStatus.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
            }

            // If ModelState is not valid or an exception occurred, return to the 'Booking' view with validation or error messages
            return View("~/Views/Dashboard/Booking.cshtml", CreateBookingTuple(null, booking));
        }


        [HttpPost]
        public IActionResult DeleteBooking(int bookingId)
        {
            // Call the service method to delete the booking
            bool deletionResult = _bookingService.DeleteBooking(bookingId);

            if (deletionResult)
            {
                // Redirect to the Booking.cshtml view in the Dashboard folder
                return RedirectToAction("Archive", "Dashboard");
            }
            else
            {
                // Handle the case where the booking was not found or deletion failed
                // You might want to display an error message or redirect to an error page
                return RedirectToAction("Error");
            }
        }




        public (BookingID?, Bookings?) CreateBookingTuple(BookingID? bookingID, Bookings? booking) => (bookingID, booking);
    }
}
