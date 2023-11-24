using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finals.data
{
    public class MyLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        // Add other properties as needed
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MyLog> Logs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add entity configurations here
            modelBuilder.Entity<MyLog>(entity =>
            {
                // Configuration for MyLog entity
                entity.Property(e => e.Message).IsRequired();
                // Add other configurations as needed
            });
        }

    }
}
