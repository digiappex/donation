using System;
using System.Collections.Generic;
using System.Text;

namespace donationProjectBLL.models
{
    public class itemdonationModel
    {
        public int itemDonationID { get; set; }
        public DateTime donationDate { get; set; }
        public string Receiver { get; set; }
        public string Item { get; set; }
        public string Amount { get; set; }
        public string DonorName { get; set; }
    }
}
