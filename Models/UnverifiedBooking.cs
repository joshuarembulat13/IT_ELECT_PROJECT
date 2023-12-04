using System.ComponentModel.DataAnnotations;

namespace Finals.Models
{
    public class UnverifiedBooking
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Pax is required")]
        public int Pax { get; set; }

    }
}
