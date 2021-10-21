using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using async_inn.Data;
using async_inn.Models;
using Microsoft.EntityFrameworkCore;

namespace async_inn.Services
{
    public class DatabaseAmenityRepository : IAmenityRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseAmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<List<Amenity>> GetAll()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenity> GetById(int id)
        {
            return await _context.Amenities.FindAsync();
        }

        public async Task Insert(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }
    }
}
