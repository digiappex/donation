using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using donationProjectDLL.DomainContext;
using donationProjectDLL.Domains;
using donationProjectBLL.userAPIBLLFunctions;
using donationProjectBLL.models;
using System.Net;

namespace donationProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class itemDonationAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public itemDonationAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/itemDonationAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<itemDonation>>> GetitemDonation()
        {
            return await _context.itemDonation.ToListAsync();
        }

        // POST: api/GetItemDonationbyDonor            
        [HttpGet("getItemDonationByDonor/{id}")]
        public async Task<ActionResult<IEnumerable<itemdonationModel>>> getItemDonationByDonor(int id)
        {
            itemDonationBLL ItemDonation = new itemDonationBLL(_context);
            var result = await ItemDonation.ItemDonationList(id);
            if(result==null){
                return Ok(Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.NO_RESULT_RETURNED));
            }
            return result;
        }

        // GET: api/itemDonationAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<itemDonation>> GetitemDonation(int id)
        {
            var itemDonation = await _context.itemDonation.FindAsync(id);

            if (itemDonation == null)
            {
                return Ok(donationProjectBLL.enums.messageCode.GENERAL_EXCEPTION);
            }

            return itemDonation;
        }

        // PUT: api/itemDonationAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutitemDonation(int id, itemDonation itemDonation)
        {
            if (id != itemDonation.itemDonationId)
            {
                return BadRequest();
            }

            _context.Entry(itemDonation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemDonationExists(id))
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

        // POST: api/itemDonationAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<itemDonation>> PostitemDonation(itemDonation itemDonation)
        {
            _context.itemDonation.Add(itemDonation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetitemDonation", new { id = itemDonation.itemDonationId }, itemDonation);
        }

        // DELETE: api/itemDonationAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<itemDonation>> DeleteitemDonation(int id)
        {
            var itemDonation = await _context.itemDonation.FindAsync(id);
            if (itemDonation == null)
            {
                return NotFound();
            }

            _context.itemDonation.Remove(itemDonation);
            await _context.SaveChangesAsync();

            return itemDonation;
        }

        private bool itemDonationExists(int id)
        {
            return _context.itemDonation.Any(e => e.itemDonationId == id);
        }
    }
}
