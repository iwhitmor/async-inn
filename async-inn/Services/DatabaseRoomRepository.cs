using System;
using System.Collections.Generic;
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

        public async Task<List<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetById(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task Insert(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }
    }
}
