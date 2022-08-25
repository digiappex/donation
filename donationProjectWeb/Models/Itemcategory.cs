using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Itemcategory : DbContext
    {
        public Itemcategory()
        {
            Itemdetails = new HashSet<Itemdetails>();
        }

        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }

        public virtual ICollection<Itemdetails> Itemdetails { get; set; }
    }
}
