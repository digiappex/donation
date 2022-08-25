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
    public class itemDetailsAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public itemDetailsAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/itemDetailsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<itemDetails>>> GetitemDetails()
        {
            return await _context.itemDetails.ToListAsync();
        }

        // GET: api/itemDetailsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<itemDetails>> GetitemDetails(int id)
        {
            var itemDetails = await _context.itemDetails.FindAsync(id);

            if (itemDetails == null)
            {
                return NotFound();
            }

            return itemDetails;
        }

        // PUT: api/itemDetailsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutitemDetails(int id, itemDetails itemDetails)
        {
            if (id != itemDetails.itemDetailId)
            {
                return BadRequest();
            }

            _context.Entry(itemDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemDetailsExists(id))
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

        // POST: api/itemDetailsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<itemDetails>> PostitemDetails(itemDetails itemDetails)
        {
            _context.itemDetails.Add(itemDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetitemDetails", new { id = itemDetails.itemDetailId }, itemDetails);
        }

        // DELETE: api/itemDetailsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<itemDetails>> DeleteitemDetails(int id)
        {
            var itemDetails = await _context.itemDetails.FindAsync(id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            _context.itemDetails.Remove(itemDetails);
            await _context.SaveChangesAsync();

            return itemDetails;
        }

        private bool itemDetailsExists(int id)
        {
            return _context.itemDetails.Any(e => e.itemDetailId == id);
        }
    }
}
