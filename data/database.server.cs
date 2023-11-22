using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace database.service
{
    public class Database : IdentityDbContext<Users>
    {
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<User> User { get; set; }


        public Database(DbContextOptions<Database> options) : base(options) { }
    }
}
