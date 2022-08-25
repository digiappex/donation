using System;
using donationProjectDLL.DomainContext;
using donationProjectDLL.Domains;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using donationProjectBLL.models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using donationProjectBLL.enums;

namespace donationProjectBLL.userAPIBLLFunctions
{
    public class itemDonationBLL
    {
        private donationProjectDBContext _dbContext;
        public itemDonationBLL(donationProjectDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<itemdonationModel>> ItemDonationList(int donarId)
        {
            var selectUser = _dbContext.userRecord.Where(x => x.userRecordId == donarId).FirstOrDefault();
            if(selectUser!=null){
                var result = await (from m in _dbContext.itemDonation
                            join i in _dbContext.itemDetails on m.itemDonationId equals i.itemDetailId
                            join u in _dbContext.userRecord on m.receiverId equals u.userRecordId
                            where m.donationId == donarId
                            select new itemdonationModel
                            {
                                itemDonationID = m.itemDonationId,
                                donationDate = m.donationDate,                           
                                Receiver = u.userFirstName + "" + u.userLastName,
                                Item = i.itemName,
                                Amount = m.ammount,
                                DonorName = selectUser.userFirstName + " " + selectUser.userLastName
                            }).ToListAsync();

               
                return (result.Any())?result:null;
            }
            else{return null;}
        }
    }
}
