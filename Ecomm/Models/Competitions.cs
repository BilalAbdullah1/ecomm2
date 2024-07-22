using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.Models
{
    public class Competitions
    {
        [Key]
        public int CopetitionId { get; set; }
        [Required]
        [DisplayName("Competitions Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Competitions Start Date")]
        public DateTime CompStartDate { get; set; }
        [Required]
        [DisplayName("Competitions End Date")]
        public DateTime CompEndDate { get; set; }
        [Required]
        [DisplayName("Award Details")]
        public string AwardDetails { get; set; }
    }
}