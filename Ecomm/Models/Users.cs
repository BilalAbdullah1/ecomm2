using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Models
{
    public class Users
    {
        [Key]
        public int Uid { get; set; }
        [Required]

        [DisplayName("User Name")]
        public string UName { get; set; }
        [Required]

        [DisplayName("User Email")]
        public string UEmail { get; set; }
        [Required]

        [DisplayName("User Password")]
        public string UPassword { get; set; }
        [Required]
        [DisplayName("Roles")]
        public int URole { get; set; }
        [ForeignKey("URole")]
        public Role Role { get; set; }
    }
}
