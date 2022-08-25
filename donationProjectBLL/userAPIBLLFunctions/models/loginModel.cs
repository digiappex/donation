using System;
namespace donationProjectBLL.models{
    public class loginModel{
        public string loginName{get;set;}
        public string password{get;set;}
    }
    public class loginVerifyModel{
        public int userId{get;set;}
        public string lastName{get;set;}
        public string firstName{get;set;}
        public string userGuid{get;set;}
        public string userType{get;set;}
        public string userCNIC{get;set;}
        public string message{get;set;}
    }
}