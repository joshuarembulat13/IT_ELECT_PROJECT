using System;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Role
{
    Customer, Admin
}

public class User : IdentityUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string DisplayName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(6, ErrorMessage = "The Minimum length is {1} and the maximum is {2}")]
    public new string PasswordHash { get; set; }


    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }




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
