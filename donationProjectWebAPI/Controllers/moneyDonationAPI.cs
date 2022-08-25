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

namespace donationProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moneyDonationAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public moneyDonationAPI(donationProjectDBContext context)
        {          
            _context = context;
        }

        // GET: api/moneyDonationAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<moneyDonation>>> GetmoneyDonation()
        {          
            return await _context.moneyDonation.ToListAsync();          
        }

        // GET: api/GetMoneyDonationbyDonor/5
        [HttpGet("getMoneyDonationByDonor/{id}")]
        public async Task<ActionResult<IEnumerable<moneydonationModel>>> getMoneyDonationByDonor(int id)
        {
            moneydonationBLL moneyDonation = new moneydonationBLL(_context);
            var result = await moneyDonation.MoneyDonationList(id);
              if(result==null){
                  
                return Ok(Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.NO_RESULT_RETURNED));
            }
            return result;
        }

        // GET: api/moneyDonationAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<moneyDonation>> GetmoneyDonation(int id)
        {
            var moneyDonation = await _context.moneyDonation.FindAsync(id);

            if (moneyDonation == null)
            {
                return NotFound();
            }

            return moneyDonation;
        }

        // PUT: api/moneyDonationAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmoneyDonation(int id, moneyDonation moneyDonation)
        {
            if (id != moneyDonation.moneyDonationId)
            {
                return BadRequest();
            }

            _context.Entry(moneyDonation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!moneyDonationExists(id))
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

        // POST: api/moneyDonationAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<moneyDonation>> PostmoneyDonation(moneyDonation moneyDonation)
        {
            _context.moneyDonation.Add(moneyDonation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetmoneyDonation", new { id = moneyDonation.moneyDonationId }, moneyDonation);
        }

        // DELETE: api/moneyDonationAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<moneyDonation>> DeletemoneyDonation(int id)
        {
            var moneyDonation = await _context.moneyDonation.FindAsync(id);
            if (moneyDonation == null)
            {
                return NotFound();
            }

            _context.moneyDonation.Remove(moneyDonation);
            await _context.SaveChangesAsync();

            return moneyDonation;
        }

        private bool moneyDonationExists(int id)
        {
            return _context.moneyDonation.Any(e => e.moneyDonationId == id);
        }
    }
}
