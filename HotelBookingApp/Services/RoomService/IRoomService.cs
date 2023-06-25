using HotelBookingApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingApp.Services.RoomService
{
    public interface IRoomService
    {
        Task<ServiceResponse<Room>> GetRoomAsync(int roomId);
        Task<ServiceResponse<List<Room>>> GetRoomsAsync();
        Task<ServiceResponse<Room>> CreateRoomAsync(Room room);
    }
}
