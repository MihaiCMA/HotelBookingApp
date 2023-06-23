﻿using HotelBookingApp.Models;
using HotelBookingApp.Services.BookingService;
using HotelBookingApp.Services.CustomerService;
using HotelBookingApp.Services.RoomService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;

namespace HotelBookingApp.Controllers
{
    public class BookingController: Controller
    {
        private readonly IRoomService _roomService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;

        public BookingController(IRoomService roomService, UserManager<IdentityUser> userManager, ICustomerService customerService, IBookingService bookingService)
        {
            _roomService = roomService;
            _userManager = userManager;
            _customerService = customerService;
            _bookingService = bookingService;
        }

        [Route("booking/{roomId}")]
        public async Task<IActionResult> Index(int roomId)
        {
            var room = (await _roomService.GetRoomAsync(roomId)).Data;
            dynamic model = new CheckoutViewModel();
            model.Room = room;
            model.Booking = new Booking();
            model.Booking.CheckInDate = DateTime.Now.AddDays(1);
            model.Booking.CheckOutDate = DateTime.Now.AddDays(2);
            model.Booking.RoomId = room.Id;
            model.Booking.Room = room;

            var bookings = (await _bookingService.GetBookingsAsync()).Data.Where(b => b.RoomId == roomId).ToList();


            ViewData["Bookings"] = bookings;

            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }

            return View(model);
        }

        [HttpPost]
        [Route("booking/submit")]
        public async Task<IActionResult> Submit(CheckoutViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var customer = (await _customerService.GetCustomerByUserAsync(user)).Data;

            model.Booking.CustomerId = customer.Id;
            var response = await _bookingService.CreateBookingAsync(model.Booking);

            if (!response.Success)
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction("Index", new { roomId = model.Booking.RoomId });
            }
            else
            {
                return RedirectToAction("Confirmation");
            }
        }

        [HttpGet]
        [Route("booking/confirmation")]
        public async Task<IActionResult> Confirmation()
        {
            return View();
        }
    }
}
