using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using async_inn.Models;
using async_inn.Models.DTOs;

namespace async_inn.Services
{
    public interface IAmenityRepository
    {
        Task<List<AmenityDto>> GetAll();

        Task<Amenity> GetById(int id);

        Task Insert(Amenity amenity);

        Task<bool> TryDelete(int id);
    }
}
