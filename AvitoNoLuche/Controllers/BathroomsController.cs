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
    public class BathroomsController : ControllerBase
    {
        private readonly user05_3Context _context;

        public BathroomsController(user05_3Context context)
        {
            _context = context;
        }
        [HttpPost("get")]
        public async Task<ActionResult<IEnumerable<Bathroom>>> GetBathroomsPost()
        {
            return await _context.Bathrooms.ToListAsync();
        }     
    }
}
