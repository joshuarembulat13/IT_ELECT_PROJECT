using System;
using System.ComponentModel.DataAnnotations;

public class Room
{

    [Key]
    public int roomID { get; set; }

    [Required(ErrorMessage = "Room name is required")]
    public string name { get; set; }
    [Required(ErrorMessage = "Price is required")]
    public float price { get; set; }
    public int userID { get; set; }

}