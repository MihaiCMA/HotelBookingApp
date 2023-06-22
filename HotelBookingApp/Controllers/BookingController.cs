using HotelBookingApp.Services.CustomerService;

namespace HotelBookingApp.Controllers
{
    public class BookingController
    {
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
    }
}
