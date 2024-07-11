using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Models
{
    public class Users
    {
        [Key]
        public int Uid { get; set; }
        [Required]
        public string UName { get; set; }
        [Required]
        public string UEmail { get; set; }
        [Required]
        public string UPassword { get; set; }
        [Required]
        public int URole { get; set; }
        [ForeignKey("URole")]
        public Role Role { get; set; }
    }
}
