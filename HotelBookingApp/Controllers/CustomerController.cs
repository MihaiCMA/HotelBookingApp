using HotelBookingApp.Models;
using HotelBookingApp.Services.CustomerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly UserManager<IdentityUser> _userManager;

        public CustomerController(ICustomerService customerService, UserManager<IdentityUser> userManager)
        {
            _customerService = customerService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("customer/edit/{customerId}")]
        public async Task<ViewResult> EditCustomer(int customerId)
        {
            Customer customer; 
            if(customerId == 0)
            {
                var user = await _userManager.GetUserAsync(User);
                customer = (await _customerService.GetCustomerByUserAsync(user)).Data;
            }
            else
            {
                customer = (await _customerService.GetCustomerByIdAsync(customerId)).Data;
            }
            return View(customer);
        }


        [HttpPost]
        [Route("customer/save")]
        public async Task<IActionResult> SaveCustomer(Customer customer)
        {
            var userId = (await _customerService.GetCustomerByIdAsync(customer.Id)).Data.UserId;
            customer.UserId = userId;
            await _customerService.UpdateCustomerAsync(customer);

            return RedirectToAction("EditCustomer", new { customerId = customer.Id });
        }
    }
}
