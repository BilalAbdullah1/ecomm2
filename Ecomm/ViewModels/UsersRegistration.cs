using System.ComponentModel.DataAnnotations;

namespace Ecomm.ViewModels
{
    public class UsersRegistration
    {
        [Key]
        public int Uid { get; set; }
        [Required]
        public string UName { get; set; }
        [Required]
        public string UEmail { get; set; }
        [Required]
        public string UPassword { get; set; }
        [Compare("UPassword")]
        public string ConfirmPassword {  get; set; }
        [Required]
        public int URole { get; set; }
    }
}
