using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Models
{
    public class Submissions
    {
        [Key]
        public int SubId { get; set; }
        [Required]
        public int CompetitionId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string StaffRemarks { get; set; }
        [Required]
        public string File {  get; set; }
        [Required]
        public bool? Mark { get; set; } = false;
        [ForeignKey("CompetitionId")]
        public Competitions Competitions { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

    }
}
