using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagerApi.Models;

namespace UserManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ArandaContext _context;

        public UserController(ArandaContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var dataUser = from userx in await _context.User.ToListAsync()
            join rolex in await _context.Role.ToListAsync() on userx.IdRole equals rolex.IdRole
                           select (new UserDTO
                           {
                               IdRole = userx.IdRole,
                               FullName = userx.FullName,
                               Address = userx.Address,
                               Age = userx.Age,
                               Description = rolex.Description,
                               Email = userx.Email,
                               IdUser = userx.IdUser,
                               Name = userx.Name,
                               Password = userx.Password,
                               Phone = userx.Phone
                           });

            return  dataUser.ToList();
        }

        // GET: api/User/Filter
        [Route("Filter")]
        [EnableCors("*")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Filter(string userName, int idRol) {
            var dataUser = from userx in await _context.User.ToListAsync()
                           join rolex in await _context.Role.ToListAsync() on userx.IdRole equals rolex.IdRole
                           where userx.Name ==  userName && userx.IdRole == idRol
                           select (new UserDTO
                           {
                               IdRole = userx.IdRole,
                               FullName = userx.FullName,
                               Address = userx.Address,
                               Age = userx.Age,
                               Description = rolex.Description,
                               Email = userx.Email,
                               IdUser = userx.IdUser,
                               Name = userx.Name,
                               Password = userx.Password,
                               Phone = userx.Phone
                           });

            return dataUser.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User/Authentication
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("Authentication")]
        [EnableCors("*")]
        public IActionResult Authentication([FromBody] AuthtenticationDTO data)
        {
            var userf = from userx in _context.User
                        where userx.Name == data.Name &&
                        userx.Password == data.Password
                        select userx;
            if (userf.FirstOrDefault() != null)
            {
                return Ok("200");
            }
            else
            {
                return NotFound();
            }

        }



        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.IdUser }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.IdUser == id);
        }
    }
}
