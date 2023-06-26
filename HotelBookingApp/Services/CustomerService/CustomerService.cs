using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Customer>> CreateCustomerAsync(IdentityUser identityUser)
        {
            var customer = new Customer
            {
                UserId = identityUser.Id,
                Email = identityUser.Email,
            };
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Customer>
            {
                Data = customer
            };
        }

        public async Task<ServiceResponse<Customer>> GetCustomerByIdAsync(int customerId)
        {
            var customer = _context.Customers.Where(c => c.Id == customerId).FirstOrDefault();
            return new ServiceResponse<Customer>()
            {
                Data = customer
            };
        }

        public async Task<ServiceResponse<Customer>> GetCustomerByUserAsync(IdentityUser identityUser)
        {
            var customer = await _context.Customers.Where(c => c.UserId == identityUser.Id).FirstOrDefaultAsync();
            return new ServiceResponse<Customer>
            {
                Data = customer
            };
        }

        public async Task<ServiceResponse<List<Customer>>> GetCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return new ServiceResponse<List<Customer>>
            {
                Data = customers
            };
        }

        public async Task<ServiceResponse<Customer>> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                var response = _context.Customers.Update(customer);
                await _context.SaveChangesAsync();

                return new ServiceResponse<Customer>()
                {
                    Data = customer
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Customer>()
                {
                    Message = ex.Message
                };
            }
        }
    }
}
