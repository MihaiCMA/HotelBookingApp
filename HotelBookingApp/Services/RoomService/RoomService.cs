using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Services.RoomService
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Room>>> GetRoomsAsync()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return new ServiceResponse<List<Room>> { 
                Data =rooms 
            };
        }

        public async Task<ServiceResponse<Room>> GetRoomAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return new ServiceResponse<Room> { Success = false };
            }

            return new ServiceResponse<Room>
            {
                Data = room
            };
        }

        public async Task<ServiceResponse<Room>> CreateRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Room>()
            {
                Data = room
            };
        }
    }
}
