using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Models
{
    public class Product
    {
        [Key]
        public int Pid { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public string PName { get; set; }
        [Required]
        public string PDescription { get; set; }
        [Required]
        public double PPrice { get; set; }
        [Required]
        public string? PImage { get; set; }
        [Required]
        public int BId{ get; set; }
        [Required]
        public int CId { get; set; }
        [ForeignKey("BId")]
        public Brand Brand { get; set; }
        [ForeignKey("CId")]
        public Category category { get; set; }
    }
}
