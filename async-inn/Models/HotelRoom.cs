using System;
namespace async_inn.Models
{
    public class HotelRoom
    {
       public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public decimal Price { get; set; }

        public bool PetFriendly { get; set; }

    }
}
