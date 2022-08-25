using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace donationProjectWeb.Models
{
    public partial class Efmigrationshistory : DbContext
    {
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}
