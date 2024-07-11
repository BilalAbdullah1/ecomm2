using System.ComponentModel.DataAnnotations;

namespace Ecomm.Models
{
    public class Role
    {
        [Key]
        public int RId { get; set; }
        [Required]
        public string RName { get; set; }    
    }
}
