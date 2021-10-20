using System;
using async_inn.Data;

namespace async_inn.Services
{
    public class DatabaseAmenityRepository : IAmenityRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseAmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
    }
}
