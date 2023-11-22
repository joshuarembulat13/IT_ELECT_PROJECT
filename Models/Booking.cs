using System;
using System.ComponentModel.DataAnnotations;

public enum status
{

    Pending, Paid, Cancelled

}


public class Booking
{

    [Key]
    public int id { get; set; }
    [Required(ErrorMessage = "Start Date is required")]
    public DateTime startDate { get; set; }
    [Required(ErrorMessage = "End date is required")]
    public DateTime endDate { get; set; }
    [Required(ErrorMessage = "Pax is required")]
    public int pax { get; set; }
    public int userID { get; set; }
    public int roomTypeID { get; set; }
    public int bookOrder { get; set; }

}