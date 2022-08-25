using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Usertype : DbContext
    {
        public Usertype()
        {
            Userrecord = new HashSet<Userrecord>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Userrecord> Userrecord { get; set; }
    }
}
