using System;
using async_inn.Data;

namespace async_inn.Services
{
    public class DatabaseRoomRepository : IRoomRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
    }
}
