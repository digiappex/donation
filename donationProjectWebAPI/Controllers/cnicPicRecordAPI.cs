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
    public class cnicPicRecordAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public cnicPicRecordAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/cnicPicRecordAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cnicPicRecord>>> GetcnicPicRecord()
        {
            return await _context.cnicPicRecord.ToListAsync();
        }

        // GET: api/cnicPicRecordAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cnicPicRecord>> GetcnicPicRecord(int id)
        {
            var cnicPicRecord = await _context.cnicPicRecord.FindAsync(id);

            if (cnicPicRecord == null)
            {
                return NotFound();
            }

            return cnicPicRecord;
        }

        // PUT: api/cnicPicRecordAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutcnicPicRecord(int id, cnicPicRecord cnicPicRecord)
        {
            if (id != cnicPicRecord.cnicPicRecordId)
            {
                return BadRequest();
            }

            _context.Entry(cnicPicRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cnicPicRecordExists(id))
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

        // POST: api/cnicPicRecordAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<cnicPicRecord>> PostcnicPicRecord(cnicPicRecord cnicPicRecord)
        {
            _context.cnicPicRecord.Add(cnicPicRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetcnicPicRecord", new { id = cnicPicRecord.cnicPicRecordId }, cnicPicRecord);
        }

        // DELETE: api/cnicPicRecordAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<cnicPicRecord>> DeletecnicPicRecord(int id)
        {
            var cnicPicRecord = await _context.cnicPicRecord.FindAsync(id);
            if (cnicPicRecord == null)
            {
                return NotFound();
            }

            _context.cnicPicRecord.Remove(cnicPicRecord);
            await _context.SaveChangesAsync();

            return cnicPicRecord;
        }

        private bool cnicPicRecordExists(int id)
        {
            return _context.cnicPicRecord.Any(e => e.cnicPicRecordId == id);
        }
    }
}
