using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manage_Tourings.Models.Touring;

namespace Manage_Tourings.Models
{
    public class ManageTouringsContext : DbContext
    {
        public ManageTouringsContext (DbContextOptions<ManageTouringsContext> options)
            : base(options)
        {
        }

        public DbSet<Manage_Tourings.Models.Touring.Touring> Touring { get; set; }
    }
}
