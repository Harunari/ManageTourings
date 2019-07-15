using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_Tourings.Models.Touring.Plan
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public string Title { get; set; }
    }
}
