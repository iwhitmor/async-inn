using System;
using async_inn.Data;

namespace async_inn.Services.Identity
{
    public class DatabaseHotelRoomRepository : IHotelRoomRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseHotelRoomRepository(AsyncInnDbContext context)
        {
            this._context = context;
        }
    }
}
