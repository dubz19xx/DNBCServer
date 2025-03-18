using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBServer.Data;
using DBServer.Models;
using DBServer.Helper;
using Microsoft.AspNetCore.Identity.Data;
using System.Text;

namespace DBServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginInfoesController : ControllerBase
    {
        private readonly LoginDataContext _context;

        public LoginInfoesController(LoginDataContext context)
        {
            _context = context;
        }

        // GET: api/LoginInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginInfo>>> GetLoginInfo()
        {
            return await _context.LoginInfo.ToListAsync();
        }

        // GET: api/LoginInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginInfo>> GetLoginInfo(string id)
        {
            var loginInfo = await _context.LoginInfo.FindAsync(id);

            if (loginInfo == null)
            {
                return NotFound();
            }

            return loginInfo;
        }

        // PUT: api/LoginInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginInfo(string id, LoginInfo loginInfo)
        {
            if (id != loginInfo.Username)
            {
                return BadRequest();
            }

            _context.Entry(loginInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginInfoExists(id))
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] DNLoginRequest loginRequest)
        {
            var user = await _context.LoginInfo
                .Where(u => u.Username == loginRequest.Username)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("User not found");
            }
            if (user.Password != loginRequest.Password)
            {
                return Unauthorized("Incorrect password");
            }


            return Ok(user.DNAddress);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] DNLoginRequest loginRequest)
        {
            var user = await _context.LoginInfo
                .Where(u => u.Username == loginRequest.Username)
                .FirstOrDefaultAsync();

            return Ok(user.DNAddress);
        }

        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginInfo request)
        {
            // Check if username already exists
            var existingUsername = await _context.LoginInfo
                .FirstOrDefaultAsync(x => x.Username == request.Username);

            if (existingUsername != null)
            {
                return BadRequest("Username already exists");
            }

            // Check if email already exists
            var existingEmail = await _context.LoginInfo
                .FirstOrDefaultAsync(x => x.EmailId == request.EmailId);

            if (existingEmail != null)
            {
                return BadRequest("Email already exists");
            }

            // Create a new LoginInfo object and save it to the database
            var newLoginInfo = new LoginInfo
            {
                Username = request.Username,
                EmailId = request.EmailId,
                DNAddress = request.DNAddress, // Assuming you get the DNAddress from the request
                Password = request.Password // You might want to hash this password before saving it
            };

            string newAddy = Helper.DNHelpers.GenerateRandomString(32);
            newLoginInfo.DNAddress = newAddy;

            _context.LoginInfo.Add(newLoginInfo);
            await _context.SaveChangesAsync();

            return Ok("Registration successful");
        }
    

    // POST: api/LoginInfoes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
        public async Task<ActionResult<LoginInfo>> PostLoginInfo(LoginInfo loginInfo)
        {
            _context.LoginInfo.Add(loginInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginInfoExists(loginInfo.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginInfo", new { id = loginInfo.Username }, loginInfo);
        }

        // DELETE: api/LoginInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginInfo(string id)
        {
            var loginInfo = await _context.LoginInfo.FindAsync(id);
            if (loginInfo == null)
            {
                return NotFound();
            }

            _context.LoginInfo.Remove(loginInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginInfoExists(string id)
        {
            return _context.LoginInfo.Any(e => e.Username == id);
        }
    }
}
