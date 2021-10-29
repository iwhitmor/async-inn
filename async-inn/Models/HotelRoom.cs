using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace async_inn.Models
{
    public class HotelRoom
    {
       public int HotelId { get; set; }
       public int RoomNumber { get; set; }


       [Column(TypeName = "money")]
       public decimal Price { get; set; }

       public bool PetFriendly { get; set; }


       public Hotel Hotel { get; set; }
    }
}
