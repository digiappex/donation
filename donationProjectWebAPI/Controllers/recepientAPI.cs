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
    public class recepientAPI : ControllerBase
    {
        private readonly donationProjectDBContext _context;
        
        public recepientAPI(donationProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/recepientAPI
        [HttpGet("getReceipent")]
        public async Task<ActionResult<IEnumerable<userRecord>>> getRecepient(string cnic,int areaId)
        {   
            try{
                if(String.IsNullOrEmpty(cnic)&&areaId==0)
                {
                    return BadRequest(Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.CNIC_AREAID_REQUIRED));
                } 
                else{         
                    if(!String.IsNullOrEmpty(cnic)&&areaId==0){
                        var result =await _context.userRecord.Where(m => m.UserType.id == 3&&m.userCNIC==cnic).ToListAsync();
                        if(result.Any())
                            return result;
                        
                        else
                            return Ok(Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.NO_RESULT_RETURNED));

                    }
                    else if(String.IsNullOrEmpty(cnic)&&areaId!=0){
                       var result= await _context.userRecord.Where(m => m.UserType.id == 3&&m.areaId.areaId==areaId).ToListAsync();
                        if(result.Any())
                            return result;
                        
                        else
                            return Ok(Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.NO_RESULT_RETURNED));

                    }
                    else if(!String.IsNullOrEmpty(cnic)&&areaId!=0){
                        var result= await _context.userRecord.Where(m => m.UserType.id == 3&&m.userCNIC==cnic&&m.areaId.areaId==areaId).ToListAsync();
                        if(result.Any())
                            return result;
                        
                        else
                            return Ok(Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.NO_RESULT_RETURNED));
                    }
                return Ok(Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.NO_RESULT_RETURNED));
                }
            }
            catch(Exception ex){
                return BadRequest(Enum.GetName(typeof(donationProjectBLL.enums.messageCode),donationProjectBLL.enums.messageCode.GENERAL_EXCEPTION));
            }
        }
    }
}
