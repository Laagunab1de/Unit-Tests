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
    public class TypeWindowsController : ControllerBase
    {
        private readonly user05_3Context _context;

        public TypeWindowsController(user05_3Context context)
        {
            _context = context;
        }
        [HttpPost("get")]
        public async Task<ActionResult<IEnumerable<TypeWindow>>> GetTypeWindowsPost()
        {
            return await _context.TypeWindows.ToListAsync();
        }
    }
}
