using System;
using System.ComponentModel.DataAnnotations;

public enum Status
{
    Pending,
    Paid,
    Cancelled
}

public class Booking
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

    public Status BookingStatus { get; set; }
}
