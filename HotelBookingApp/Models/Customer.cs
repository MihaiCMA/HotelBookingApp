using Microsoft.AspNetCore.Identity;

namespace HotelBookingApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public IdentityUser User { get; set; }
    }
}
