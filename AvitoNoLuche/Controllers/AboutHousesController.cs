using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvitoNoLuche;
using AvitoNoLuche.Models;

namespace AvitoNoLuche.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutHousesController : ControllerBase
    {
        private readonly user05_3Context _context;
        public int id4put;

        public AboutHousesController(user05_3Context context)
        {
            _context = context;
        }
        // GET: api/AboutHouses/5
        [HttpPost("getone")]
        public async Task<ActionResult<AboutHouse>> GetAboutHouse([FromBody]int id)
        {           
            var aboutHouse = await _context.AboutHouses.Include(s => s.IdParkingNavigation).Include(s => s.IdTypeHouseNavigation)
                .Include(s => s.IdStatusNavigation).FirstOrDefaultAsync(s => s.Id == id);
            if (aboutHouse == null)
            {
                return NotFound();
            }

            return aboutHouse;
        }

        // PUT: api/AboutHouses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Put")]
        public async Task<IActionResult> PutAboutHouse([FromBody]AboutHouse aboutHouse)
        {
            id4put = aboutHouse.Id;

            if (id4put != aboutHouse.Id)
            {
                return BadRequest();
            }
            var origin = _context.AboutHouses.FirstOrDefault(s => s.Id == aboutHouse.Id);      
            try
            {
                aboutHouse.IdStatusNavigation = _context.Statuses.Find(aboutHouse.IdStatus);
                aboutHouse.IdTypeHouseNavigation = _context.TypeHouses.Find(aboutHouse.IdTypeHouse);
                aboutHouse.IdParkingNavigation = _context.Parkings.Find(aboutHouse.IdParking);
                _context.Entry(origin).CurrentValues.SetValues(aboutHouse);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutHouseExists(id4put))
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

        // POST: api/AboutHouses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("post")]
        public async Task<ActionResult<AboutHouse>> PostAboutHouse([FromBody] AboutHouse aboutHouse)
        {
            aboutHouse.IdStatusNavigation = _context.Statuses.Find(aboutHouse.IdStatus);
            aboutHouse.IdTypeHouseNavigation = _context.TypeHouses.Find(aboutHouse.IdTypeHouse);           
            aboutHouse.IdParkingNavigation = _context.Parkings.Find(aboutHouse.IdParking);

            _context.AboutHouses.Add(aboutHouse);
            await _context.SaveChangesAsync();

            return aboutHouse;
        }

        // DELETE: api/AboutHouses/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAboutHouse([FromBody] int id)
        {
            var aboutHouse = await _context.AboutHouses.FindAsync(id);
            if (aboutHouse == null)
            {
                return NotFound();
            }

            _context.AboutHouses.Remove(aboutHouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AboutHouseExists(int id)
        {
            return _context.AboutHouses.Any(e => e.Id == id);
        }
    }
}
