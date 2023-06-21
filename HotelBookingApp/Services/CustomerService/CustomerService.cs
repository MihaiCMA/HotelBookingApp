using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Services.CustomerService
{
    public class CustomerService: ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Customer>>> GetCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return new ServiceResponse<List<Customer>>
            {
                Data = customers
            };
        }
    }
}
