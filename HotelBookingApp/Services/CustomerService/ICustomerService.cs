using HotelBookingApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingApp.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<List<Customer>>> GetCustomersAsync();
        Task<ServiceResponse<Customer>> GetCustomerByUserAsync(IdentityUser identityUser);
        Task<ServiceResponse<Customer>> GetCustomerByIdAsync(int customerId);
        Task<ServiceResponse<Customer>> CreateCustomerAsync(IdentityUser identityUser);
        Task<ServiceResponse<Customer>> UpdateCustomerAsync(Customer customer);
    }
}
