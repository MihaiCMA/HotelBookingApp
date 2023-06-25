using HotelBookingApp.Models;
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
        [Route("room/createroom")]
        public IActionResult CreateRoom()
        {
            return View(new Room());
        }
        [HttpPost]
        [Route("room/createroom")]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            var response = await _roomService.CreateRoomAsync(room);
            if (response.Success)
            {
                return RedirectToAction($"Details/{room.Id}", "Room");
            }
            else
            {
                ViewData["ErrorMessage"] = "Room could not be created.";
                return View();
            }
        }
        [Route("room/{roomId}")]
        public async Task<IActionResult> Details(int roomId)
        {
            var room = (await _roomService.GetRoomAsync(roomId)).Data;
            return View(room);
        }

    }
}
