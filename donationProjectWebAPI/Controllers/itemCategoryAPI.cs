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
    public class itemCategoryAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public itemCategoryAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/itemCategoryAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<itemCategory>>> GetitemCategory()
        {
            return await _context.itemCategory.ToListAsync();
        }

        // GET: api/itemCategoryAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<itemCategory>> GetitemCategory(int id)
        {
            var itemCategory = await _context.itemCategory.FindAsync(id);

            if (itemCategory == null)
            {
                return NotFound();
            }

            return itemCategory;
        }

        // PUT: api/itemCategoryAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutitemCategory(int id, itemCategory itemCategory)
        {
            if (id != itemCategory.itemCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(itemCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemCategoryExists(id))
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

        // POST: api/itemCategoryAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<itemCategory>> PostitemCategory(itemCategory itemCategory)
        {
            _context.itemCategory.Add(itemCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetitemCategory", new { id = itemCategory.itemCategoryId }, itemCategory);
        }

        // DELETE: api/itemCategoryAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<itemCategory>> DeleteitemCategory(int id)
        {
            var itemCategory = await _context.itemCategory.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            _context.itemCategory.Remove(itemCategory);
            await _context.SaveChangesAsync();

            return itemCategory;
        }

        private bool itemCategoryExists(int id)
        {
            return _context.itemCategory.Any(e => e.itemCategoryId == id);
        }
    }
}
