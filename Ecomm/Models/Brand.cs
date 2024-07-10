using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace Ecomm.Models
{
    public class Brand
    {
        [Key]
        public int Bid { get; set; }
        [Required]
        public string BName { get; set; }   
    }
}
