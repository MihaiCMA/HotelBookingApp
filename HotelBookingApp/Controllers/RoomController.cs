using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
