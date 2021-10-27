using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using async_inn.Models;
using async_inn.Models.DTOs;

namespace async_inn.Services
{
   public interface IRoomRepository
    {
        Task<List<RoomDto>> GetAll();

        Task<Room> GetById(int id);

        Task Insert(Room room);

        Task<bool> TryDelete(int id);

        Task<bool> TryUpdate(Room room);

        Task AddAmenity(int roomId, int amenityId);

        Task RemoveAmenity(int roomId, int amenityId);
    }
}


