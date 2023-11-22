using System;
using System.ComponentModel.DataAnnotations;

public class Profile
{

    [Key]
    public int profileID { get; set; }
    [Required(ErrorMessage = "Fullname is required")]
    public string fullName { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public string address { get; set; }
    [Required(ErrorMessage = "Nationality is required")]
    public string nationality { get; set; }
    [Required(ErrorMessage = "Phone Number is required")]
    public int phone { get; set; }
    public DateTime birthday { get; set; }


}
