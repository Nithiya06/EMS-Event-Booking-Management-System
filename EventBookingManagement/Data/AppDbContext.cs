using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace EventManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<BookingConfirmation> BookingConfirmation { get; set; }
        public DbSet<Admin> Admin { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the 'TotalPrice' column in 'BookingConfirmation' entity
            modelBuilder.Entity<BookingConfirmation>()
                .Property(b => b.TotalPrice)
                .HasColumnType("decimal(18,2)");  // Specify precision and scale (18 digits in total, 2 after the decimal point)

            // Configure the 'Price' column in 'Event' entity
            modelBuilder.Entity<Event>()
                .Property(e => e.Price)
                .HasColumnType("decimal(18,2)");  // Specify precision and scale
        }
    }
}