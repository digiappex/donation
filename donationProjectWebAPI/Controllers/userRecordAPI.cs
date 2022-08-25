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

namespace donationProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userRecordAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;

        public userRecordAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/userRecordAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userRecord>>> GetuserRecord()
        {
            return await _context.userRecord.Include(m=>m.FamilyMembersRecord).Include(s=>s.ScreenNameRecord).Include(c=>c.CnicPicRecord).ToListAsync();
        }

        // GET: api/userRecordAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userRecord>> GetuserRecord(int id)
        {
            var userRecord = await _context.userRecord.Where(x=>x.userRecordId==id).Include(m=>m.FamilyMembersRecord).Include(s=>s.ScreenNameRecord).Include(c=>c.CnicPicRecord).FirstOrDefaultAsync();

            if (userRecord == null)
            {
                return NotFound();
            }

            return userRecord;
        }

        // PUT: api/userRecordAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutuserRecord(int id, userRecord userRecord)
        {
            if (id != userRecord.userRecordId)
            {
                return BadRequest();
            }

            _context.Entry(userRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userRecordExists(id))
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

        // POST: api/userRecordAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<string>> PostuserRecord(userRecord UserRecord)
        {
            try{
              
                userAPIBLL userAPI= new userAPIBLL(_context);
                return userAPI.addUser(UserRecord);
                
            }
            catch(Exception ex){
                return Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.UNABLE_TO_REGISTER_USER);
            }
          
        }
        [HttpPost("signupUser/")]
        public async Task<ActionResult<string>> signupUser(userRecord UserRecord)
        {
            try{
              
                userAPIBLL userAPI= new userAPIBLL(_context);
                return userAPI.signupUser(UserRecord);
                
            }
            catch(Exception ex){
                return Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.USER_SIGNUP_FAIL);
            }
          
        }
        [HttpPost("verifyLogin/")]
        public async Task<ActionResult<donationProjectBLL.models.loginVerifyModel>> verifyLogin(donationProjectBLL.models.loginModel loginCredentials)
        {
            try{
              
                generalBLL general= new generalBLL(_context);
                return general.verifyUser(loginCredentials);
                
            }
            catch(Exception ex){
                return null;
                
            }
          
        }


        // POST: api/userRecordAPI/addUserWithValid/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      /*  [HttpPost("addUserWithValid/")]
        public async Task<ActionResult<String>> addUserWithValid(userRecord userRecord)
        {
           var userExist = _context.userRecord.Where(m => m.userCNIC == userRecord.userCNIC).SingleOrDefault();
           var familyExist = _context.userRecord.Where(m => m.familyNumber == userRecord.familyNumber).SingleOrDefault();
            if (userExist != null || familyExist != null)
                {
                    return "user exist";
                }
            _context.userRecord.Add(userRecord);
            await _context.SaveChangesAsync();

            return "successful";
        }*/
        // DELETE: api/userRecordAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<userRecord>> DeleteuserRecord(int id)
        {
            var userRecord = await _context.userRecord.FindAsync(id);
            if (userRecord == null)
            {
                return NotFound();
            }

            _context.userRecord.Remove(userRecord);
            await _context.SaveChangesAsync();

            return userRecord;
        }

        private bool userRecordExists(int id)
        {
            return _context.userRecord.Any(e => e.userRecordId == id);
        }
    }
}
