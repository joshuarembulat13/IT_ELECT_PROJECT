using Finals.data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Finals.Models;

namespace Finals.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveBooking(Bookings book)
        {
            _dbContext.Bookings.Add(book);
            _dbContext.SaveChanges();
        }

        public void UpdateBooking(Bookings updatedBooking)
        {
            Bookings existingBooking = _dbContext.Bookings.Find(updatedBooking.Id);

            if (existingBooking != null)
            {
                existingBooking.FirstName = updatedBooking.FirstName;
                existingBooking.LastName = updatedBooking.LastName;
                existingBooking.Email = updatedBooking.Email;
                existingBooking.PhoneNumber = updatedBooking.PhoneNumber;

                _dbContext.SaveChanges();
            }
        }

        public Bookings GetMostRecentBooking()
        {
            // Order bookings by creation time (or ID) in descending order and select the first one
            return _dbContext.Bookings.OrderByDescending(b => b.CreatedAt).FirstOrDefault();
        }
    }
}
