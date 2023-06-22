namespace HotelBookingApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;



        public string Name { get; set; } = string.Empty;
        public string PaddedNumber()
        {
            return Number.ToString().PadLeft(3, '0');
        }
    }
}
