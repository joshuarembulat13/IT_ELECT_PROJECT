// using System;

// public class Class1
// {



//     public string password { get; set; }
//     public string email { get; set; }
//     public int profileID { get; set; }

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public enum Role
{

    Customer, Admin

}


public class User : IdentityUser
{
    [Key]
    public int userID { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [StringLength(6, ErrorMessage = "The Miniumum length is {6} and the maximum is {16}")]
    public string Password { get; set; }
    public Role roles { get; set; }
}

// }
// }
