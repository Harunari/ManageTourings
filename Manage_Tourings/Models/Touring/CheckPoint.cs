using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_Tourings.Models.Touring.Plan.CheckPoint
{
    public class CheckPoint
    {
        [Key]
        public int CheckPointId { get; set; }
        public int TouringId { get; set; }
        [ForeignKey("TouringId")]
        public Touring Touring { get; set; }
        public Plan Plan { get; set; }
        public HashSet<CheckPoint> NextCheckPoints { get; set; }
        public double AverageSpeedToThisPoint { get; set; }
    }
}
