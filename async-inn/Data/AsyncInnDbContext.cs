using System;
using async_inn.Models;
using async_inn.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace async_inn.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<RoomAmenity> RoomAmenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "MGM Grand", StreetAddress = "1 Las Vegas Blvd", City = "Las Vegas", State = "Nevada", Country = "USA", Phone = "800-111-1111"  },
              new Hotel { Id = 2, Name = "Flamingo", StreetAddress = "2 Las Vegas Blvd", City = "Las Vegas", State = "Nevada", Country = "USA", Phone = "800-222-2222" },
              new Hotel { Id = 3, Name = "Golden Nugget", StreetAddress = "3 Las Vegas Blvd", City = "Las Vegas", State = "Nevada", Country = "USA", Phone = "800-333-3333" }
            );
      
            modelBuilder.Entity<Room>()
                .HasData(
                    new Room { Id = 1, Name = "Luxury Suite", Layout = RoomLayout.Studio },
                    new Room { Id = 2, Name = "Deluxe Suite", Layout = RoomLayout.OneBedroom },
                    new Room { Id = 3, Name = "Penthouse Suite", Layout = RoomLayout.TwoBedroom }
                );

            modelBuilder.Entity<Amenity>()
                .HasData(
                    new Amenity { Id = 1, Name = "Mini-Bar" },
                    new Amenity { Id = 2, Name = "Large Couch" },
                    new Amenity { Id = 3, Name = "Kitchenette" }
                );

            modelBuilder.Entity<RoomAmenity>()
                .HasKey(e => new { e.AmenityId, e.RoomId}

                );

            modelBuilder.Entity<RoomAmenity>()
                .HasData(
                new RoomAmenity { AmenityId = 1, RoomId = 1 },
                new RoomAmenity { AmenityId = 2, RoomId = 2 },
                new RoomAmenity { AmenityId = 3, RoomId = 3 }
                );
        }
    }
    
}
