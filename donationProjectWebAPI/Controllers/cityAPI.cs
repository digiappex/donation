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
    public class cityAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public cityAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/cityAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<city>>> Getcity()
        {
            return await _context.city.Include(m=>m.CityAreas).ToListAsync();
        }

        // GET: api/cityAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<city>> Getcity(int id)
        {
            var city = await _context.city.AsQueryable().Include(m=>m.CityAreas).ToListAsync();
            
            var cityArea= await _context.cityArea.Where(x=>x.City.cityId==id).ToListAsync();
            //city.CityAreas=cityArea;
            if (city == null)
            {
                return NotFound();
            }

            return city.Where(x=>x.cityId==id).FirstOrDefault();
        }

        // PUT: api/cityAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcity(int id, city city)
        {
            if (id != city.cityId)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cityExists(id))
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

        // POST: api/cityAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<city>> Postcity(city city)
        {
            _context.city.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcity", new { id = city.cityId }, city);
        }

        // DELETE: api/cityAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<city>> Deletecity(int id)
        {
            var city = await _context.city.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.city.Remove(city);
            await _context.SaveChangesAsync();

            return city;
        }

        private bool cityExists(int id)
        {
            return _context.city.Any(e => e.cityId == id);
        }
    }
}
