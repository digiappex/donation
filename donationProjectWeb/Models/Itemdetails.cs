using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Itemdetails : DbContext
    {
        public int ItemDetailId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int OwnerId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Ammount { get; set; }

        public virtual Itemcategory ItemCategory { get; set; }
    }
}
