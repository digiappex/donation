using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Cnicpicrecord : DbContext
    {
        public int CnicPicRecordId { get; set; }
        public int UserRecordId { get; set; }
        public Guid UserGuid { get; set; }
        public string CnicFrontPicPath { get; set; }
        public string CnicBackPicPath { get; set; }

        public virtual Userrecord UserRecord { get; set; }
    }
}
