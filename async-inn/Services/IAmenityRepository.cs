﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using async_inn.Models;

namespace async_inn.Services
{
    public interface IAmenityRepository
    {
        Task<List<Amenity>> GetAll();
    }
}