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
    public class familyMemberRecordAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public familyMemberRecordAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/familyMemberRecordAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<familyMembersRecord>>> GetfamilyMembersRecords()
        {
            return await _context.familyMembersRecords.ToListAsync();
        }

        // GET: api/familyMemberRecordAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<familyMembersRecord>> GetfamilyMembersRecord(int id)
        {
            var familyMembersRecord = await _context.familyMembersRecords.FindAsync(id);

            if (familyMembersRecord == null)
            {
                return NotFound();
            }

            return familyMembersRecord;
        }

        // PUT: api/familyMemberRecordAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutfamilyMembersRecord(int id, familyMembersRecord familyMembersRecord)
        {
            if (id != familyMembersRecord.familyMembersRecordId)
            {
                return BadRequest();
            }

            _context.Entry(familyMembersRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!familyMembersRecordExists(id))
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

        // POST: api/familyMemberRecordAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<familyMembersRecord>> PostfamilyMembersRecord(familyMembersRecord familyMembersRecord)
        {
            _context.familyMembersRecords.Add(familyMembersRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetfamilyMembersRecord", new { id = familyMembersRecord.familyMembersRecordId }, familyMembersRecord);
        }

        // DELETE: api/familyMemberRecordAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<familyMembersRecord>> DeletefamilyMembersRecord(int id)
        {
            var familyMembersRecord = await _context.familyMembersRecords.FindAsync(id);
            if (familyMembersRecord == null)
            {
                return NotFound();
            }

            _context.familyMembersRecords.Remove(familyMembersRecord);
            await _context.SaveChangesAsync();

            return familyMembersRecord;
        }

        private bool familyMembersRecordExists(int id)
        {
            return _context.familyMembersRecords.Any(e => e.familyMembersRecordId == id);
        }
    }
}
