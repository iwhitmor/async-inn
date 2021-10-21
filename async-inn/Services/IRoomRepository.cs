using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using async_inn.Models;

namespace async_inn.Services
{
   public interface IRoomRepository
    {
        Task<List<Room>> GetAll();

        Task<Room> GetById(int id);

        Task Insert(Room room);

        Task<bool> TryDelete(int id);

        Task<bool> TryUpdate(Room room);
    }
}
