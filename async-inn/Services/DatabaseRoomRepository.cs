using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using async_inn.Data;
using async_inn.Models;
using Microsoft.EntityFrameworkCore;

namespace async_inn.Services
{
    public class DatabaseRoomRepository : IRoomRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task AddAmenity(int roomId, int amenityId)
        {
            var roomAmenity = new RoomAmenity
            {
                RoomId = roomId,
                AmenityId = amenityId
            };

            _context.RoomAmenities.Add(roomAmenity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAll()
        {
            var result = await _context.Rooms

                .Include(r => r.RoomAmenities)

                .ThenInclude(ra => ra.Amenity)

                .ToListAsync();

            return result;
        }

        public async Task<Room> GetById(int id)
        {
            return await _context.Rooms
                .Include(r => r.RoomAmenities)

                .ThenInclude(ra => ra.Amenity)

                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Insert(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenity(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities

            .FirstOrDefaultAsync(ra =>
                ra.RoomId == roomId &&
                ra.AmenityId == amenityId);

            _context.RoomAmenities.Remove(roomAmenity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> TryDelete(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return false;
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TryUpdate(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(room.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }    
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}