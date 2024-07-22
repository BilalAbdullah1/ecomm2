using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ecomm.Models
{
    public class Exhibitions
    {

        [Key]
        public int ExbId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string ExbTitle { get; set; }
        [Required]
        [DisplayName("Description")]
        public string ExbDescription { get; set; }
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
