using System.ComponentModel.DataAnnotations;
using VisionStore.Areas.Identity.Data;

namespace VisionStore.Models
{
    public class RegisterViewModel :ApplicationUser
    {
        [Required(ErrorMessage = "You must provide your first name")]
        [Display(Name = "Your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must provide your last name")]
        [Display(Name = "Your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide your Email")]
        [Display(Name = "Your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Your Password")]

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
