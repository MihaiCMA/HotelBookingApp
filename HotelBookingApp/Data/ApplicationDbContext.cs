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
                    Price = 50,
                    Name = "Ocean Suite",
                    ImageUrl = "https://cdn.jumeirah.com/-/mediadh/dh/hospitality/jumeirah/hotels/dubai/madinat-jumeirah/al-naseem-at-madinat-jumeirah/rooms/ocean-suite/al-naseem--ocean-suite--bedroom.jpg?h=1080&w=1920"
                },
                new Room
                {
                    Id = 2,
                    Number = 2,
                    Type = "Double",
                    Description = "A bigger room, but just as nice",
                    Price = 70,
                    Name = "Grizzly Suite",
                    ImageUrl = "https://www.greatwolf.com/content/dam/greatwolf/sites/www/locations/georgia/Suites/Premium/Grizzly%20Bear%20Suite/Grizzly_Bear_Suite_living-room-767x434.jpg"
                },
                new Room
                {
                    Id = 3,
                    Number = 1,
                    Type = "Single",
                    Description = "A misterious room",
                    Price = 60,
                    Name = "Egypt Suite",
                    ImageUrl = "https://osiristours.com/wp-content/uploads/2019/06/CAF_384_original.jpg"
                },
                new Room
                {
                    Id = 4,
                    Number = 4,
                    Type = "Single",
                    Description = "A room close to nature",
                    Price = 45,
                    Name = "Forest Suite",
                    ImageUrl = "https://mayaresorts.com/assets/images/ubud/accommodation/impressive-forest-suite/gallery-desktop-thumbnails/ifs-gdt-1.jpg"
                }
                );
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}