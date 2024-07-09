using System.ComponentModel.DataAnnotations;

namespace ecomm.Models
{
    public class Category
    {
        [Key]
        public int Cid { get; set; }
        [Required]
        public string category { get; set; }    
    }
}
