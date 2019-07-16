using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manage_Tourings.Models.Touring.Plan
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public int TouringId { get; set; }
        public string Title { get; set; }
        [ForeignKey("TouringId")]
        public Touring Touring { get; set; }
        public List<CheckPoint.CheckPoint> CheckPoints { get; set; }
    }
}
