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

        public async Task<ServiceResponse<bool>> CheckRoomOverlapAsync(Booking booking)
        {
            var bookings = (await GetBookingsAsync()).Data;

            if (bookings == null)
            {
                return new ServiceResponse<bool> { 
                    Success = false,
                    Message = "Error loading bookings"
                };
            }

            return new ServiceResponse<bool>
            {
                Data = !(bookings.Any(b => b.CheckInDate < booking.CheckOutDate && booking.CheckInDate < b.CheckOutDate))
            };
        }


        public async Task<ServiceResponse<Booking>> CreateBookingAsync(Booking booking)
        {
            var response = await CheckRoomOverlapAsync(booking);
            if (!response.Success)
            {
                return new ServiceResponse<Booking>
                {
                    Success = false,
                    Message = response.Message
                };
            }

            if (!response.Data)
            {
                return new ServiceResponse<Booking>
                {
                    Success = false,
                    Message = "There is an overlaping reservation for this room. Please choose another period."
                };
            }

            await _context.AddAsync(booking);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Booking>
            {
                Data = booking
            };
        }
    }
}
