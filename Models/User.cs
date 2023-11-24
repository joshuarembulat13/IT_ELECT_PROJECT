using System;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Role
{
    Customer, Admin
}

public class User : IdentityUser
{
    [Key]
<<<<<<< HEAD
    public int userID { get; set; }
    [Required(ErrorMessage = "Username is required")]
    [BindProperty]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [BindProperty]
    public string Password { get; set; }
    public Role roles { get; set; }
}
=======
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }
>>>>>>> 9428d4dab43e9630e679564bad80db5783551191

    [Required(ErrorMessage = "Username is required")]
    public string DisplayName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(6, ErrorMessage = "The Minimum length is {1} and the maximum is {2}")]
    public new string PasswordHash { get; set; }




    public Role Role { get; set; }

    // Computed property for NormalizedUserName
    public string NormalizedDisplayName
    {
        get
        {
            return DisplayName?.ToUpper()?.Normalize() ?? string.Empty;
        }
    }

}
