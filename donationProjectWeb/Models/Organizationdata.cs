using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Organizationdata : DbContext
    {
        public int OrganizationId { get; set; }
        public string LicenseNumber { get; set; }
        public Guid UserGuid { get; set; }
        public string OrganizationName { get; set; }
        public string AboutOrganization { get; set; }
        public string OrganizationAddress { get; set; }
        public bool IsActive { get; set; }
        public int? AreaId1 { get; set; }
        public int CityId { get; set; }

        public virtual Cityarea AreaId1Navigation { get; set; }
    }
}
