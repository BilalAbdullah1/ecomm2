using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.Models
{
    public class ExhibitionSubmissions
    {
        [Key]
        public int ExhibitionSubmissionID { get; set; }
        [Required]
        public int ExhibitionID { get; set; }
        [Required]
        public int SubmissionID { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Status { get; set; } = "Not Sold";
        [Required]
        public double SoldPrice { get; set; }
        [Required]
        public string CustomerDetails { get; set; }
        [Required]
        public string PaymentStatus { get; set; } = "Unpaid";

        [ForeignKey("ExhibitionID")]
        public virtual Exhibitions Exhibition { get; set; }

        [ForeignKey("SubmissionID")]
        public virtual Submissions Submission { get; set; }
    }
}
