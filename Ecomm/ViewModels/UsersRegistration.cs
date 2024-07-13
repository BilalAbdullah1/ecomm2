using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.ViewModels
{
    public class UsersRegistration
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

        [Compare("UPassword")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Roles")]
        public int URole { get; set; }
    }
}
