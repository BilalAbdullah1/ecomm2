using System.ComponentModel.DataAnnotations;

namespace Ecomm.ViewModels
{
    public class StudentRegistration
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        public string StdFirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string StdLastName { get; set; }

        [Required(ErrorMessage = "Please enter your age.")]
        [Display(Name = "Age")]
        public int StdAge { get; set; }

        [Required(ErrorMessage = "Please enter your birth date.")]
        [Display(Name = "Date of Birth")]
        public DateTime StdBirthDate { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        public string StdEmail { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string StdPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("StdPassword", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string StdConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your contact number.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Contact Number")]
        public string StdContact { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        [Display(Name = "Address")]
        public string StdAddress { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [Display(Name = "Image")]
        public string? ImageFile { get; set; }
    }
}
