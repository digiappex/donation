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
    public class screenNameRecordAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public screenNameRecordAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/screenNameRecordAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<screenNameRecord>>> GetscreenNameRecord()
        {
            return await _context.screenNameRecord.ToListAsync();
        }

        // GET: api/screenNameRecordAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<screenNameRecord>> GetscreenNameRecord(int id)
        {
            var screenNameRecord = await _context.screenNameRecord.FindAsync(id);

            if (screenNameRecord == null)
            {
                return NotFound();
            }

            return screenNameRecord;
        }

        // PUT: api/screenNameRecordAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutscreenNameRecord(int id, screenNameRecord screenNameRecord)
        {
            if (id != screenNameRecord.screenNameRecordId)
            {
                return BadRequest();
            }

            _context.Entry(screenNameRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!screenNameRecordExists(id))
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

        // POST: api/screenNameRecordAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<screenNameRecord>> PostscreenNameRecord(screenNameRecord screenNameRecord)
        {
            _context.screenNameRecord.Add(screenNameRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetscreenNameRecord", new { id = screenNameRecord.screenNameRecordId }, screenNameRecord);
        }

        // DELETE: api/screenNameRecordAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<screenNameRecord>> DeletescreenNameRecord(int id)
        {
            var screenNameRecord = await _context.screenNameRecord.FindAsync(id);
            if (screenNameRecord == null)
            {
                return NotFound();
            }

            _context.screenNameRecord.Remove(screenNameRecord);
            await _context.SaveChangesAsync();

            return screenNameRecord;
        }

        private bool screenNameRecordExists(int id)
        {
            return _context.screenNameRecord.Any(e => e.screenNameRecordId == id);
        }
    }
}
