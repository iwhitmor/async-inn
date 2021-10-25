using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using async_inn.Models;

namespace async_inn.Services
{
    public interface IAmenityRepository
    {
        Task<List<Amenity>> GetAll();

        Task<Amenity> GetById(int id);

        Task Insert(Amenity amenity);

        Task<bool> TryDelete(int id);

        Task RoomAmenity(int AmenityId, int RoomId);
    }
}
