using HotelBookingApp.Data;
using HotelBookingApp.Services.CustomerService;
using HotelBookingApp.Services.RoomService;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public async Task<IActionResult> Index()
        {
            var rooms = (await _roomService.GetRoomsAsync()).Data;
            return View(rooms);
        }

        [HttpGet]
        [Route("/{roomId}")]
        public async Task<IActionResult> Details(int roomId)
        {
            var room = (await _roomService.GetRoomAsync(roomId)).Data;
            return View(room);
        }
    }
}
