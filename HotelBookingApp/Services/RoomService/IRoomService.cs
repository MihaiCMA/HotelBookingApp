using HotelBookingApp.Models;

namespace HotelBookingApp.Services.RoomService
{
    public interface IRoomService
    {
        Task<ServiceResponse<Room>> GetRoomAsync(int roomId);
        Task<ServiceResponse<List<Room>>> GetRoomsAsync();
    }
}
