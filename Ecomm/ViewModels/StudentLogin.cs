using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.ViewModels
{
    public class StudentLogin
    {
        [Required]
        [DisplayName("Student Email")]
        public string StdEmail { get; set; }

        [Required]
        [DisplayName("Student Password")]
        public string StdPassword { get; set; }

    }
}
