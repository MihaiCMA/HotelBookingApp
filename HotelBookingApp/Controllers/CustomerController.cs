using HotelBookingApp.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    [Route("Customer")]
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

        [HttpGet("{customerId}")]
        public async Task<ViewResult> Details(int customerId)
        {
            var customers = (await _customerService.GetCustomersAsync()).Data.Where(c => c.Id == customerId).FirstOrDefault();

            return View(customers);
        }
    }
}
