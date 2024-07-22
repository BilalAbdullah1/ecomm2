using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.Models
{
    public class UpcomingExhibitions
    {
        [Key]
        public int UpExbId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string UpExbTitle { get; set; }
        [Required]
        [DisplayName("Description")]
        public string UpExbDescription { get; set; }
        [Required]
        [DisplayName("StartDate")]
        public DateTime startdate { get; set; }
        [Required]
        [DisplayName("EndDate")]
        public DateTime enddate { get; set; }
        [Required]
        [DisplayName("Location")]
        public string Location { get; set; }
    }
}
