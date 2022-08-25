using System;
using donationProjectDLL.DomainContext;
using donationProjectDLL.Domains;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using donationProjectBLL.models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace donationProjectBLL.userAPIBLLFunctions
{
    public class moneydonationBLL
    {
        private donationProjectDBContext _dbContext;
        public moneydonationBLL(donationProjectDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<moneydonationModel>> MoneyDonationList (int donarId)
        {
            var selectUser = _dbContext.userRecord.Where(x => x.userRecordId == donarId).FirstOrDefault();
            if(selectUser!=null){
                var result = await (from m in _dbContext.moneyDonation
                            join u in _dbContext.userRecord on m.receiverId equals u.userRecordId
                            where m.donationId == donarId
                            select new moneydonationModel
                            {
                                moneyDonationID = m.moneyDonationId,
                                donationDate = m.donationDate,
                                Receiver = u.userFirstName + " " + u.userLastName,
                                Amount = m.ammount,
                                DonorName = selectUser.userFirstName + " " + selectUser.userLastName
                            }).ToListAsync();

                return (result.Any())?result:null;
            }
            else 
                return null;
        }
    }
}
