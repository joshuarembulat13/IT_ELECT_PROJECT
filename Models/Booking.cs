using System;
using System.ComponentModel.DataAnnotations;

public enum Status
{
    Pending,
    Paid,
    Cancelled
}



namespace Finals.Models
{
    public class Bookings
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Pax is required")]
        public int Pax { get; set; }

        public int UserId { get; set; }

        public int RoomTypeId { get; set; }

        public int BookOrder { get; set; }

        public Status BookingStatus { get; set; } = Status.Pending;


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
