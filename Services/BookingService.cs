using Finals.data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Finals.Models;
using Microsoft.AspNetCore.Mvc;

namespace Finals.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveBooking(UnverifiedBooking unverifiedBooking)
        {
            _dbContext.UnverifiedBookings.Add(unverifiedBooking);
            _dbContext.SaveChanges();
        }
        public void SaveBooking(Bookings booking)
        {
            _dbContext.Bookings.Add(booking);
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

        public List<Bookings> GetBookings(int limit) { 
            return _dbContext.Bookings.OrderByDescending(b => b.CreatedAt).Take(limit).ToList();
        }
        
        public UnverifiedBooking GetUnverifiedBooking(int ID) {
            return _dbContext.UnverifiedBookings.Find(ID);
        }
    }
}
