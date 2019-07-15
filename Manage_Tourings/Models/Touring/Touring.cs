using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manage_Tourings.Models.Touring
{
    public class Touring
    {
        [Key]
        public int TouringId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Note { get; set; }
        public Plan.Plan Plan { get; set; }
    }
}
