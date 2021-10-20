using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using async_inn.Models;
using Microsoft.AspNetCore.Mvc;

namespace async_inn.Services
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAll();

        Task<Hotel> GetById(int id);

        Task Insert(Hotel hotel);

        Task<bool> TryDelete(int id);
    }
}
