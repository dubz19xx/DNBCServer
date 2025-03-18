using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBServer.Data;
using DBServer.Models;

namespace DBServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineNodesController : ControllerBase
    {
        private readonly OnlineNodesContext _context;

        public OnlineNodesController(OnlineNodesContext context)
        {
            _context = context;
        }

        // GET: api/OnlineNodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnlineNodes>>> GetOnlineNodes()
        {
            return await _context.OnlineNodes.ToListAsync();
        }

        // GET: api/OnlineNodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OnlineNodes>> GetOnlineNodes(string id)
        {
            var onlineNodes = await _context.OnlineNodes.FindAsync(id);

            if (onlineNodes == null)
            {
                return NotFound();
            }

            return onlineNodes;
        }

        // PUT: api/OnlineNodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnlineNodes(string id, OnlineNodes onlineNodes)
        {
            if (id != onlineNodes.DNAddress)
            {
                return BadRequest();
            }

            _context.Entry(onlineNodes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnlineNodesExists(id))
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

        // POST: api/OnlineNodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OnlineNodes>> PostOnlineNodes(OnlineNodes onlineNodes)
        {
            _context.OnlineNodes.Add(onlineNodes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OnlineNodesExists(onlineNodes.DNAddress))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOnlineNodes", new { id = onlineNodes.DNAddress }, onlineNodes);
        }

        [HttpPost("GoOnline")]
        public async Task<IActionResult> GoOnline([FromBody] GoOnlineRequest request)
        {
            string clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            //string clientIp = "192.1.1.1";
            OnlineNodes newnode = new OnlineNodes { DNAddress = request.DNAddress, IPAddress = clientIp };  

            _context.OnlineNodes.Add(newnode);
            await _context.SaveChangesAsync();
            return Ok("Node Online");
        }

        [HttpPost("GoOffline")]
        public async Task<IActionResult> GoOffline([FromBody] GoOnlineRequest request)
        {
            var onlineNodes = await _context.OnlineNodes.FindAsync(request.DNAddress);
            if (onlineNodes == null)
            {
                return NotFound();
            }   

            _context.OnlineNodes.Remove(onlineNodes);
            await _context.SaveChangesAsync();

            return Ok("Node offline");
        }


        // DELETE: api/OnlineNodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnlineNodes(string id)
        {
            var onlineNodes = await _context.OnlineNodes.FindAsync(id);
            if (onlineNodes == null)
            {
                return NotFound();
            }

            _context.OnlineNodes.Remove(onlineNodes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnlineNodesExists(string id)
        {
            return _context.OnlineNodes.Any(e => e.DNAddress == id);
        }
    }
}
