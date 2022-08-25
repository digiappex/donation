using System;
using System.Collections.Generic;
using System.Text;
using donationProjectDLL;
using donationProjectDLL.DomainContext;
using System.Linq;

namespace donationProjectBLL.userAPIBLLFunctions
{
   
   
    public class recepientDataList
    {

        private donationProjectDBContext _dbContext;
        public recepientDataList(donationProjectDBContext dBContext) {
            _dbContext = dBContext;
        }
    }
}
