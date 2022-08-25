using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Screennamerecord : DbContext
    {
        public int ScreenNameRecordId { get; set; }
        public Guid UserGuid { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public int UserRecordId { get; set; }
        public bool IsActive { get; set; }

        public virtual Userrecord UserRecord { get; set; }
    }
}
