using Manage_Tourings.Models.Touring.Plan.CheckPoint;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage_Tourings.Models.Touring
{
    public class Touring
    {
        [Key]
        public int TouringId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Note { get; set; }
        [Required]
        public List<Plan.Plan> Plans { get; set; }
        public List<CheckPoint> CheckPoints { get; set; }
    }
}
