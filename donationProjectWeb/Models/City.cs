using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class City : DbContext
    {
        public City()
        {
            Cityarea = new HashSet<Cityarea>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Cityarea> Cityarea { get; set; }
    }
}
