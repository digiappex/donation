using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using donationProjectDLL.DomainContext;
using donationProjectDLL.Domains;

namespace donationProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userTypeAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public userTypeAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/userTypeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userType>>> GetuserType()
        {
            return await _context.userType.ToListAsync();
        }

        // GET: api/userTypeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userType>> GetuserType(int id)
        {
            var userType = await _context.userType.FindAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            return userType;
        }

        // PUT: api/userTypeAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutuserType(int id, userType userType)
        {
            if (id != userType.id)
            {
                return BadRequest();
            }

            _context.Entry(userType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userTypeExists(id))
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

        // POST: api/userTypeAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<userType>> PostuserType(userType userType)
        {
            _context.userType.Add(userType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetuserType", new { id = userType.id }, userType);
        }

        // DELETE: api/userTypeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<userType>> DeleteuserType(int id)
        {
            var userType = await _context.userType.FindAsync(id);
            if (userType == null)
            {
                return NotFound();
            }

            _context.userType.Remove(userType);
            await _context.SaveChangesAsync();

            return userType;
        }

        private bool userTypeExists(int id)
        {
            return _context.userType.Any(e => e.id == id);
        }
    }
}
