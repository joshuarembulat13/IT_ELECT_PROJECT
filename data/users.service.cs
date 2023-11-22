


using Microsoft.AspNetCore.Identity;

public class Users : IdentityUser
{
    public string Username { get; set; }
    public string Password { get; set; }
}