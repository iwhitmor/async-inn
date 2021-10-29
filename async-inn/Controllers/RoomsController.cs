using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using async_inn.Data;
using async_inn.Models;
using async_inn.Services;
using async_inn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace async_inn.Controllers
{
    [Authorize(Roles = "District Manager, Property Manager, Agent")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository rooms;
        private readonly AsyncInnDbContext _context;

        public RoomsController(IRoomRepository rooms, AsyncInnDbContext context)
        {
            this.rooms = rooms;
            _context = context;
        }

        // GET: api/Rooms
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            return await rooms.GetAll();
        }

        // GET: api/Rooms/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await rooms.GetById(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager")]
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await rooms.Insert(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var deleteSucceeded = await rooms.TryDelete(id);

            if (!deleteSucceeded)

            {
                return NotFound();
            }

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await rooms.AddAmenity(roomId, amenityId);
            return NoContent();
        }

        [Authorize(Roles = "District Manager, Agent")]
        [HttpDelete]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await rooms.RemoveAmenity(roomId, amenityId);
            return NoContent();
        }
    }
}
