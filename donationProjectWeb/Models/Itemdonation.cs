using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Itemdonation : DbContext
    {
        public int ItemDonationId { get; set; }
        public DateTime DonationDate { get; set; }
        public int DonationId { get; set; }
        public int ReceiverId { get; set; }
        public int ItemId { get; set; }
        public string Ammount { get; set; }
    }
}
