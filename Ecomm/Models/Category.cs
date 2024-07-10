using System.ComponentModel.DataAnnotations;

namespace Ecomm.Models
{
    public class Category
    {
        [Key]
        public int Cid { get; set; }
        [Required]
        public string category { get; set; }    
    }
}
