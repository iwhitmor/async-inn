using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace async_inn.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public RoomLayout Layout { get; set; }

        //Reverse Navigation Properties
        public List<RoomAmenity> RoomAmenities { get; set; }
    }

    public enum RoomLayout
    {
        Studio = 0,
        OneBedroom = 1,
        TwoBedroom = 2,
    } 
}
