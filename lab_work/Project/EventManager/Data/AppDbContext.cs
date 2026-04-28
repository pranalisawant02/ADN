namespace EventManager.Data
{
    using Microsoft.EntityFrameworkCore;
    using EventManager.Models; // ✅ ADD THIS LINE

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}