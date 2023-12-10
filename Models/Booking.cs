using System;
using System.ComponentModel.DataAnnotations;

public enum Status
{
    Pending = 0,
    Paid = 1,
    Cancelled = 2
}


public enum RoomType
{

    Standard,
    Deluxe,
    Supreme,
    Suite,
    Family

}


namespace Finals.Models
{
    public class Bookings
    {

        [Key]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EndDate { get; set; }

        public int Pax { get; set; }

        public RoomType RoomType { get; set; }

        public Status BookingStatus { get; set; }

        public Boolean ArchiveStatus { get; set; } = false;

        // Other properties specific to your Booking model
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Citizenship { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
