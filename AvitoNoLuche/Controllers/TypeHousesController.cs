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
    public class TypeHousesController : ControllerBase
    {
        private readonly user05_3Context _context;

        public TypeHousesController(user05_3Context context)
        {
            _context = context;
        }
        [HttpPost("get")]
        public async Task<ActionResult<IEnumerable<TypeHouse>>> GetTypeHousesPost()
        {
            return await _context.TypeHouses.ToListAsync();
        }
    }
}
