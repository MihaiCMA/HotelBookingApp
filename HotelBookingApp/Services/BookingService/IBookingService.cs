using HotelBookingApp.Models;

namespace HotelBookingApp.Services.BookingService
{
    public interface IBookingService
    {
        Task<ServiceResponse<Booking>> GetBookingAsync(int bookingId);
        Task<ServiceResponse<List<Booking>>> GetBookingsAsync();
        Task<ServiceResponse<Boolean>> CheckRoomOverlapAsync(Booking booking);
        Task<ServiceResponse<Booking>> CreateBookingAsync(Booking booking);
    }
}
