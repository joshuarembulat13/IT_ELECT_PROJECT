using System;
using System.ComponentModel.DataAnnotations;

public enum Status
{
    Pending,
    Paid,
    Cancelled
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

        [Required(ErrorMessage = "Start Date is required")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Pax is required")]
        public int Pax { get; set; }

        public int UserId { get; set; }

        public RoomType RoomType { get; set; }

        public int BookOrder { get; set; }

        public Status BookingStatus { get; set; } = Status.Pending;

        public Boolean ArchiveStatus { get; set; } = false;

        // Other properties specific to your Booking model
        [Required(ErrorMessage = "Firstname is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Citizenship is required")]
        public string? Citizenship { get; set; }
        [Required(ErrorMessage = "Phonenumber is required")]
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
