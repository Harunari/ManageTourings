using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manage_Tourings.Models.Touring;
using Manage_Tourings.Models.Touring.Plan;

namespace Manage_Tourings.Models
{
    public class ManageTouringsContext : DbContext
    {
        public ManageTouringsContext (DbContextOptions<ManageTouringsContext> options)
            : base(options)
        {
        }

        public DbSet<Touring.Touring> Tourings { get; set; }
        public DbSet<Plan> Plans { get; set; }
    }
}
