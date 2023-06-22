using HotelBookingApp.Models;
using HotelBookingApp.Services.CustomerService;
using HotelBookingApp.Services.RoomService;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace HotelBookingApp.Controllers
{
    public class BookingController: Controller
    {
        private readonly IRoomService _roomService;

        public BookingController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [Route("booking/{roomId}")]
        public async Task<IActionResult> Index(int roomId)
        {
            var room = (await _roomService.GetRoomAsync(roomId)).Data;
            dynamic bookingCheckoutModel = new CheckoutViewModel();
            bookingCheckoutModel.Room = room;
            bookingCheckoutModel.Booking = new Booking();
            bookingCheckoutModel.Booking.CheckInDate = DateTime.Now.AddDays(1);
            bookingCheckoutModel.Booking.CheckOutDate = DateTime.Now.AddDays(2);
            return View(bookingCheckoutModel);
        }

        [HttpPost]
        [Route("booking/submit")]
        public async Task<IActionResult> Submit(Booking booking)
        {
            // Process the submitted booking data
            // Example: Save the booking to the database or perform any necessary operations

            // Redirect to a success or confirmation page
            return RedirectToAction("Confirmation");
        }
    }
}
