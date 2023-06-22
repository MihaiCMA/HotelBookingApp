using HotelBookingApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingApp.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<List<Customer>>> GetCustomersAsync();
        Task<ServiceResponse<Customer>> CreateCustomerAsync(IdentityUser identityUser);
    }
}
