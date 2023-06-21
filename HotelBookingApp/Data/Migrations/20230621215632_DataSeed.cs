using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingApp.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f6b0f090-8857-40a3-885a-c63a2507b988", 0, "d19ea7db-6450-4698-a507-f44029215f30", "mihai.costar99@gmail.com", true, true, null, "MIHAI.COSTAR99@GMAIL.COM", "MIHAI.COSTAR99@GMAIL.COM", "AQAAAAEAACcQAAAAEINxA840cC+vljpKZaHltbSYLb8xv2ljKtFERgogtJUsQnuJxaE4g0NCwS1aeSPm6Q==", "NULL", false, "USIJR3TCWTENSFS7B3OMLRRRRRFOQEIE", false, "mihai.costar99@gmail.com" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "Number", "Price", "Type" },
                values: new object[] { 1, "Just a nice room", 3, 50, "Single" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Phone", "UserId" },
                values: new object[] { 1, "Oradea, nr 1", "mihai.costar99@gmail.com", "Mihai", "Costar", "0766520998", "f6b0f090-8857-40a3-885a-c63a2507b988" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6b0f090-8857-40a3-885a-c63a2507b988");
        }
    }
}
