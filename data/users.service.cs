using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Users : IdentityUser
{
<<<<<<< HEAD
    public string Email { get; set; }
=======
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }

    public string Username { get; set; }
>>>>>>> 9428d4dab43e9630e679564bad80db5783551191
    public string Password { get; set; }
}
