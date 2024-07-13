using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ecomm.ViewModels
{
    public class UserLogin
    {

        [Required]
        [DisplayName("User Email")]
        public string UEmail { get; set; }

        [Required]
        [DisplayName("User Password")]
        public string UPassword { get; set; }

    }
}
