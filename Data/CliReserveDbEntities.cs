using CliReserve.Entities;
using CliReserve.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace CliReserve.Data
{
    public class CliReserveDbEntities : IdentityDbContext<User>
    {
        public CliReserveDbEntities(DbContextOptions options) : base(options) { }
        public virtual DbSet<Clir> Clirs { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<SeatType> SeatTypes { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            });

            builder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithOne(u => u.Booking)
            .HasForeignKey<User>(u => u.BookingId);
        }
    }
}
