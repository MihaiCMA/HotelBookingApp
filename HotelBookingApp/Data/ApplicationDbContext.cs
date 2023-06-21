using HotelBookingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUser>().HasKey(iu => new { iu.Id });

            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUser>().HasData(
                new Microsoft.AspNetCore.Identity.IdentityUser
                {
                    Id = "f6b0f090-8857-40a3-885a-c63a2507b988",
                    UserName = "mihai.costar99@gmail.com",
                    NormalizedUserName = "MIHAI.COSTAR99@GMAIL.COM",
                    Email = "mihai.costar99@gmail.com",
                    NormalizedEmail = "MIHAI.COSTAR99@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEINxA840cC+vljpKZaHltbSYLb8xv2ljKtFERgogtJUsQnuJxaE4g0NCwS1aeSPm6Q==",
                    SecurityStamp = "USIJR3TCWTENSFS7B3OMLRRRRRFOQEIE",
                    ConcurrencyStamp = "d19ea7db-6450-4698-a507-f44029215f30",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Mihai",
                    LastName = "Costar",
                    Email = "mihai.costar99@gmail.com",
                    Phone = "0766520998",
                    Address = "Oradea, nr 1",
                    UserId = "f6b0f090-8857-40a3-885a-c63a2507b988"
                }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Number = 3,
                    Type = "Single",
                    Description = "Just a nice room",
                    Price = 50
                }
                );
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}