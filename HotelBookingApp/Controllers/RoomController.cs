using HotelBookingApp.Models;
using HotelBookingApp.Services.RoomService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBookingApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoomController(IRoomService roomService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roomService = roomService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AssignUserRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // Check if the role exists
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }
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
