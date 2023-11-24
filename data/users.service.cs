


using Microsoft.AspNetCore.Identity;

public class Users : IdentityUser
{
    public string Email { get; set; }
    public string Password { get; set; }
}