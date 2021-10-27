using System;
using System.Collections.Generic;

namespace async_inn.Models.DTOs
{
    public class RoomDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RoomLayout Layout { get; set; }
        public List<AmenityDto> Amenities { get; set; }
    }
}
