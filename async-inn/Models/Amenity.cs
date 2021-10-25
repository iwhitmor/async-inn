using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace async_inn.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //Navigation properties
        public List<RoomAmenity> RoomAmenities { get; set; }
    }
}
