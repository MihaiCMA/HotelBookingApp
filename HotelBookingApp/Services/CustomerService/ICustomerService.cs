using HotelBookingApp.Models;

namespace HotelBookingApp.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<List<Customer>>> GetCustomersAsync();
    }
}
