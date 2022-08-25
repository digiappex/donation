using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Cityarea : DbContext
    {
        public Cityarea()
        {
            Organizationdata = new HashSet<Organizationdata>();
            Userrecord = new HashSet<Userrecord>();
        }

        public int AreaId { get; set; }
        public int? CityId { get; set; }
        public string AreaName { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Organizationdata> Organizationdata { get; set; }
        public virtual ICollection<Userrecord> Userrecord { get; set; }
    }
}
