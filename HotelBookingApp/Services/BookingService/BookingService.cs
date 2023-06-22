using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Booking>>> GetBookingsAsync()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return new ServiceResponse<List<Booking>>
            {
                Data = bookings
            };
        }

        public async Task<ServiceResponse<Booking>> GetBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                return new ServiceResponse<Booking> { Success = false };
            }

            return new ServiceResponse<Booking>
            {
                Data = booking
            };
        }
    }
}
