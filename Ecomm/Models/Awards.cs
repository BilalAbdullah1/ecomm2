using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Ecomm.Models
{
    public class Awards
    {
        [Key]
        public int AwardId { get; set; }
        [Required]
        public string AwardDescription { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        [Required]
        public int CompetitionId { get; set; }
        [ForeignKey("CompetitionId")]
        public Competitions Competitions { get; set; }
    }
}
