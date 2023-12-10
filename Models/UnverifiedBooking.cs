using System.ComponentModel.DataAnnotations;

namespace Finals.Models
{
    public class UnverifiedBooking
    {

        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Pax { get; set; }

    }
}
