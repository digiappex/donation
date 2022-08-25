using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using donationProjectDLL.DomainContext;
using donationProjectDLL.Domains;
using donationProjectWebAPI.Models;
namespace donationProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cityAreaAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public cityAreaAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/cityAreaAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cityArea>>> GetcityArea()
        {
            return await _context.cityArea.Include(m=>m.UserRecords).Include(m=>m.OrganizationData).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<cityArea>>> GetAreaByCity(int id)
        {
            return await _context.cityArea.Where(x=>x.City.cityId==id).ToListAsync();
        }


        // GET: api/cityAreaAPI/getAreaAndCityName/1
         [HttpGet("getAreaAndCityName/{id}")]
         public async Task<ActionResult<IEnumerable<cityAreaModel>>> getAreaAndCityName(int id)
        {
            try{
                var q=(from p in _context.city join
                d in _context.cityArea on p.cityId equals d.City.cityId
                where p.cityId==id
                select new cityAreaModel {
                    cityName=p.cityName,
                    areaName=d.areaName
                }).ToListAsync();
                return await q;
            }
            catch{
                return BadRequest();
            }
          //  return await _context.cityArea.Where(x=>x.City.cityId==id).ToListAsync();
        }


        // GET: api/cityAreaAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cityArea>> GetcityArea(int id)
        {
            var cityArea = await _context.cityArea.FindAsync(id);

            if (cityArea == null)
            {
                return NotFound();
            }

            return cityArea;
        }

        // PUT: api/cityAreaAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutcityArea(int id, cityArea cityArea)
        {
            if (id != cityArea.areaId)
            {
                return BadRequest();
            }

            _context.Entry(cityArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cityAreaExists(id))
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

        // POST: api/cityAreaAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<cityArea>> PostcityArea(cityArea cityArea)
        {
            _context.cityArea.Add(cityArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetcityArea", new { id = cityArea.areaId }, cityArea);
        }

        // DELETE: api/cityAreaAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<cityArea>> DeletecityArea(int id)
        {
            var cityArea = await _context.cityArea.FindAsync(id);
            if (cityArea == null)
            {
                return NotFound();
            }

            _context.cityArea.Remove(cityArea);
            await _context.SaveChangesAsync();

            return cityArea;
        }

        private bool cityAreaExists(int id)
        {
            return _context.cityArea.Any(e => e.areaId == id);
        }
    }
}
