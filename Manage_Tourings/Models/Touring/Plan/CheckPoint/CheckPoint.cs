using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_Tourings.Models.Touring.Plan.CheckPoint
{
    public class CheckPoint
    {
        public int Id { get; set; }
        public Touring Touring { get; set; }
        public HashSet<CheckPoint> NextCheckPoints { get; set; }
        public Plan Plan { get; set; }
        public Plan PlanOfNextCheckPoint { get; set; }
        public double AverageSpeedToThisPoint { get; set; }
    }
}
