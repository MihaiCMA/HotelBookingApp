using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingApp.Data.Migrations
{
    public partial class RoomSeedsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Number", "Price", "Type" },
                values: new object[] { 2, "A bigger room, but just as nice", "https://www.greatwolf.com/content/dam/greatwolf/sites/www/locations/georgia/Suites/Premium/Grizzly%20Bear%20Suite/Grizzly_Bear_Suite_living-room-767x434.jpg", "Grizzly Suite", 2, 70, "Double" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Number", "Price", "Type" },
                values: new object[] { 3, "A misterious room", "https://osiristours.com/wp-content/uploads/2019/06/CAF_384_original.jpg", "Egypt Suite", 1, 60, "Single" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Number", "Price", "Type" },
                values: new object[] { 4, "A room close to nature", "https://mayaresorts.com/assets/images/ubud/accommodation/impressive-forest-suite/gallery-desktop-thumbnails/ifs-gdt-1.jpg", "Forest Suite", 4, 45, "Single" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
