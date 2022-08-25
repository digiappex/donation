using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Userrecord : DbContext
    {
        public int UserRecordId { get; set; }
        public Guid UserGuid { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserCnic { get; set; }
        public string FamilyNumber { get; set; }
        public string UserAddress { get; set; }
        public string UserAddressPerCnic { get; set; }
        public string EmailAddress { get; set; }
        public int CityId { get; set; }
        public int? AreaId1 { get; set; }
        public bool IsActive { get; set; }
        public int? UserTypeid { get; set; }

        public virtual Cityarea AreaId1Navigation { get; set; }
        public virtual Usertype UserType { get; set; }
        public virtual Cnicpicrecord Cnicpicrecord { get; set; }
        public virtual Familymembersrecords Familymembersrecords { get; set; }
        public virtual Screennamerecord Screennamerecord { get; set; }
    }
}
