namespace HotelBookingApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
