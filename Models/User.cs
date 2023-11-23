// using System;

// public class Class1
// {



//     public string password { get; set; }
//     public string email { get; set; }
//     public int profileID { get; set; }

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public enum Role
{

    Customer, Admin

}


public class User
{
    [Key]
    public int userID { get; set; }
    [Required(ErrorMessage = "Username is required")]
    [BindProperty]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [BindProperty]
    public string Password { get; set; }
    public Role roles { get; set; }
}

// }
// }
