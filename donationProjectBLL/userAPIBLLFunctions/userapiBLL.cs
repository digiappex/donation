using System;
using donationProjectDLL.DomainContext;
using donationProjectDLL.Domains;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace donationProjectBLL.userAPIBLLFunctions{
    public class userAPIBLL{
        private donationProjectDBContext _dbContext;
        public userAPIBLL(donationProjectDBContext dBContext){
            _dbContext=dBContext;
        }
            public string addUser(userRecord users){
           try{
                generalBLL general=new generalBLL(_dbContext);
                if(general.validateExisitingUserRecord(users.userCNIC,users.familyNumber))
                    return Enum.GetName(typeof(enums.messageCode),enums.messageCode.USER_ALREADY_EXISIT);
                else{    
                    userRecord r = new userRecord(){
                    userFirstName=users.userFirstName,
                    userLastName=users.userLastName,
                    userAddress=users.userAddress,
                    userAddressPerCNIC=users.userAddressPerCNIC,
                    userCNIC=users.userCNIC,
                    userGuid=users.userGuid,
                    UserType=_dbContext.userType.Where(x=>x.id==users.UserType.id).SingleOrDefault(),
                    areaId=_dbContext.cityArea.Where(x=>x.areaId==users.areaId.areaId).SingleOrDefault(),
                    emailAddress=users.emailAddress,
                    isActive=true,
                    cityId=users.cityId,
                    familyNumber=users.familyNumber
                    
                    };
                    _dbContext.userRecord.Add(r);
                    _dbContext.SaveChangesAsync();
                     return Enum.GetName(typeof(enums.messageCode),enums.messageCode.USER_REGISTER_SUCESSFULLY);
                }
                
           }
           catch(Exception ex){
               return Enum.GetName(typeof(enums.messageCode),enums.messageCode.UNABLE_TO_REGISTER_USER);
           }
            

        }
        public string signupUser(userRecord users){
            try{
                generalBLL general=new generalBLL(_dbContext);
                if(general.validateExisitingUserRecord(users.userCNIC,users.familyNumber))
                    return Enum.GetName(typeof(enums.messageCode),enums.messageCode.USER_ALREADY_EXISIT);
                userRecord r = new userRecord(){
                    userFirstName=users.userFirstName,
                    userLastName=users.userLastName,
                    userAddress=users.userAddress,
                    userAddressPerCNIC=users.userAddressPerCNIC,
                    userCNIC=users.userCNIC,
                    userGuid=users.userGuid,
                    UserType=_dbContext.userType.Where(x=>x.id==users.UserType.id).SingleOrDefault(),
                    areaId=_dbContext.cityArea.Where(x=>x.areaId==users.areaId.areaId).SingleOrDefault(),
                    emailAddress=users.emailAddress,
                    isActive=true,
                    cityId=users.cityId,
                    familyNumber=users.familyNumber
                    
            };
            screenNameRecord s= new screenNameRecord(){
                userGuid=users.userGuid,
                username=users.userCNIC,
                userPassword=users.ScreenNameRecord.userPassword,
                UserRecord=r,
                isActive=true
            };
            cnicPicRecord c = new cnicPicRecord(){
                cnicBackPicPath=users.userGuid.ToString()+users.CnicPicRecord.cnicBackPicPath,
                cnicFrontPicPath=users.userGuid.ToString()+users.CnicPicRecord.cnicFrontPicPath,
                userGuid=users.userGuid,
                UserRecord=r,
            };
                _dbContext.userRecord.Add(r);
                _dbContext.screenNameRecord.Add(s);
                _dbContext.cnicPicRecord.Add(c);
                _dbContext.SaveChanges();
            return Enum.GetName(typeof(enums.messageCode),enums.messageCode.USER_SIGNUP_SUCCESSFULL);
           }
           catch(Exception ex){
               return Enum.GetName(typeof(enums.messageCode),enums.messageCode.USER_SIGNUP_FAIL);
           }
        }
    }
}