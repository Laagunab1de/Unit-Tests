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
    public class UsersController : ControllerBase
    {
        private readonly user05_3Context _context;

        public UsersController(user05_3Context context)
        {
            _context = context;
        }
        // GET: api/Users
        [HttpPost("get")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersPost()
        {
            return await _context.Users.ToListAsync();
        }
        //auth method /auth
        [HttpPost("Auth")]
        public async Task<ActionResult<User>> AuthUser([FromBody]Auth auth)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Number == auth.Login && s.Password == auth.Password);

            return user ?? new User();
        }
        [HttpPost("SignUp")]
        public async Task<ActionResult<User>> PostUserSignUp([FromBody]User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
