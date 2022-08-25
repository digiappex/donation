using System;
using donationProjectDLL.DomainContext;
using donationProjectDLL.Domains;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace donationProjectBLL.userAPIBLLFunctions{
    public class generalBLL{
        private donationProjectDBContext _dbContext;
        public generalBLL(donationProjectDBContext dBContext){
            _dbContext=dBContext;
        }
        public bool validateExisitingUserRecord(string? cnic=null,string? familyNumber=null){
            if(!String.IsNullOrEmpty(cnic)||!String.IsNullOrEmpty(familyNumber)){
                if(!(string.IsNullOrEmpty(cnic))){
                     var userExist = _dbContext.userRecord.Where(m => m.userCNIC == cnic.ToString()).SingleOrDefault();
                     return (userExist!=null)?true:false;
                }
                else{
                     var familyExist = _dbContext.userRecord.Where(m => m.familyNumber == familyNumber.ToString()).SingleOrDefault();
                    return (familyExist!=null)?true:false;
                }
            }
            return false;
        }
        public models.loginVerifyModel verifyUser(models.loginModel credentials){
           try{
                var record= _dbContext.screenNameRecord.Where(x=>x.username==credentials.loginName&&x.userPassword==credentials.password&&x.isActive==true).Include(u=>u.UserRecord).SingleOrDefault();
                if(record!=null){
                        
                        var q=(from p in _dbContext.userType
                                join d in _dbContext.userRecord
                                on p.id equals d.UserType.id
                                where d.userRecordId==record.userRecordId
                                select p.typeName).SingleOrDefault();
                        
                        return new models.loginVerifyModel(){
                            userGuid=record.userGuid.ToString(),
                            userType=q,
                            firstName=record.UserRecord.userFirstName,
                            lastName=record.UserRecord.userLastName,
                            userId=record.UserRecord.userRecordId,
                            userCNIC=record.UserRecord.userCNIC,
                            message=Enum.GetName(typeof(enums.messageCode),enums.messageCode.LOGIN_SUCCESSFULL)
                        };
                }
                else{
                    return new models.loginVerifyModel(){
                        message=Enum.GetName(typeof(enums.messageCode),enums.messageCode.INVALID_CREDENTIALS)
                    };
                }
           }
           catch(Exception ex){
               return new models.loginVerifyModel{
                        message=Enum.GetName(typeof(enums.messageCode),enums.messageCode.GENERAL_EXCEPTION)
                    };
           }
        }

    }
}