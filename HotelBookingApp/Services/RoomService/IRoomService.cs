using HotelBookingApp.Models;

namespace HotelBookingApp.Services.RoomService
{
    public interface IRoomService
    {
        Task<ServiceResponse<List<Room>>> GetRoomsAsync();
    }
}
