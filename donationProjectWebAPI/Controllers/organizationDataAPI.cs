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
    public class organizationDataAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public organizationDataAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/organizationDataAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<organizationData>>> GetorganizationData()
        {
            return await _context.organizationData.ToListAsync();
        }

        // GET: api/organizationDataAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<organizationData>> GetorganizationData(int id)
        {
            var organizationData = await _context.organizationData.FindAsync(id);

            if (organizationData == null)
            {
                return NotFound();
            }

            return organizationData;
        }

        // PUT: api/organizationDataAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutorganizationData(int id, organizationData organizationData)
        {
            if (id != organizationData.organizationId)
            {
                return BadRequest();
            }

            _context.Entry(organizationData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!organizationDataExists(id))
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

        // POST: api/organizationDataAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<organizationData>> PostorganizationData(organizationData organizationData)
        {
            _context.organizationData.Add(organizationData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetorganizationData", new { id = organizationData.organizationId }, organizationData);
        }

        // DELETE: api/organizationDataAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<organizationData>> DeleteorganizationData(int id)
        {
            var organizationData = await _context.organizationData.FindAsync(id);
            if (organizationData == null)
            {
                return NotFound();
            }

            _context.organizationData.Remove(organizationData);
            await _context.SaveChangesAsync();

            return organizationData;
        }

        private bool organizationDataExists(int id)
        {
            return _context.organizationData.Any(e => e.organizationId == id);
        }
    }
}
