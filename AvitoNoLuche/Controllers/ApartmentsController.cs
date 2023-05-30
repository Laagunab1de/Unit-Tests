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
    public class ApartmentsController : ControllerBase
    {
        private readonly user05_3Context _context;
        private int id4put { get; set; }

        public ApartmentsController(user05_3Context context)
        {
            _context = context;
        }

        // GET: api/Apartments
        [HttpPost("get")]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetApartmentsPost()
        {
            return await _context.Apartments.ToListAsync();
        }

        // GET: api/Apartments/5
        [HttpPost("getone")]
        public async Task<ActionResult<Apartment>> GetApartment([FromBody] int id)
        {
            var apartment = await _context.Apartments.Include(s=>s.IdTransactionTypeNavigation).Include(s=>s.IdhouseNavigation)
                .Include(s=>s.IdRepairNavigation).Include(s=>s.IdTypeWindowsNavigation).Include(s=>s.IdBathroomtypeNavigation).Include(s=>s.IdUserNavigation).
                Include(s=>s.IdBathroomtype1).FirstOrDefaultAsync(s=>s.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return apartment;
        }
        
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PutApp")]
        public async Task<IActionResult> PutApartment([FromBody]Apartment apartment)
        {
            //id4put = apartment.Id;
            //if (id4put != apartment.Id)
            //{
            //    return BadRequest();
            //}
            try
            {
                apartment.IdUserNavigation = _context.Users.Find(apartment.IdUser);
                apartment.IdBathroomtype1 = _context.Bathrooms.Find(apartment.IdBathroomtype);
                apartment.IdBathroomtypeNavigation = _context.BalconyTypes.Find(apartment.IdBathroomtype);
                apartment.IdhouseNavigation = _context.AboutHouses.Find(apartment.Idhouse);
                apartment.IdTransactionTypeNavigation = _context.TransactionTypes.Find(apartment.IdTransactionType);
                apartment.IdTypeWindowsNavigation = _context.TypeWindows.Find(apartment.IdTypeWindows);
                apartment.IdRepairNavigation = _context.Repairs.Find(apartment.IdRepair);
                _context.Entry(apartment).State = EntityState.Modified;                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(id4put))
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
        // POST: api/Apartments/postapp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("postapp")]
        public async Task<ActionResult<Apartment>> PostApartment([FromBody]Apartment apartment)
        {
           
            apartment.IdUserNavigation = _context.Users.Find(apartment.IdUser);
            apartment.IdBathroomtype1 = _context.Bathrooms.Find(apartment.IdBathroomtype);
            apartment.IdBathroomtypeNavigation = _context.BalconyTypes.Find(apartment.IdBathroomtype);
            apartment.IdhouseNavigation = _context.AboutHouses.Find(apartment.Idhouse);
            apartment.IdTransactionTypeNavigation = _context.TransactionTypes.Find(apartment.IdTransactionType);
            apartment.IdTypeWindowsNavigation = _context.TypeWindows.Find(apartment.IdTypeWindows);
            apartment.IdRepairNavigation = _context.Repairs.Find(apartment.IdRepair);
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return apartment;
        }

        // DELETE: api/Apartments/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteApartment([FromBody] int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }

            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(e => e.Id == id);
        }
    }
}
