using HotelBookingApp.Data;
using HotelBookingApp.Services.BookingService;
using HotelBookingApp.Services.CustomerService;
using HotelBookingApp.Services.RoomService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddRoles<IdentityRole>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IBookingService, BookingService>();

            var app = builder.Build();

            // Seed default roles
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Create default roles if they don't exist
                var roles = new[] { "Admin", "User" };
                foreach (var role in roles)
                {
                    var roleExists = await roleManager.RoleExistsAsync(role);
                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Room}/{action=Index}");

            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}
