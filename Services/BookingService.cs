using Finals.data;

namespace Finals.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveBooking(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
        }
    }

}
