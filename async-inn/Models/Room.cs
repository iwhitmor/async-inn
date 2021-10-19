using System;
using System.ComponentModel.DataAnnotations;

namespace async_inn.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Layout { get; set; }
    }

    public enum RoomLayout
    {
        Studio = 0,
        OneBedroom = 1,
        TwoBedroom = 2,
    }
}
