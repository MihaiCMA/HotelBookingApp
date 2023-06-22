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
    }
}
