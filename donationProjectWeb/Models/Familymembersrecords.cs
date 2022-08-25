using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Familymembersrecords : DbContext
    {
        public int FamilyMembersRecordId { get; set; }
        public int UserRecordId { get; set; }
        public string NumberOfFamilyMembers { get; set; }

        public virtual Userrecord UserRecord { get; set; }
    }
}
