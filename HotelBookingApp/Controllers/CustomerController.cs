using HotelBookingApp.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ViewResult> Details(int customerId)
        {
            var customers = (await _customerService.GetCustomersAsync()).Data.Where(c => c.Id == customerId).FirstOrDefault();

            return View(customers);
        }
    }
}
