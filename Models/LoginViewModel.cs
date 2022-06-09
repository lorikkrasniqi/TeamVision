using System.ComponentModel.DataAnnotations;
using VisionStore.Areas.Identity.Data;

namespace VisionStore.Models
{
    public class LoginViewModel : ApplicationUser
    {
        public string Id { get; set; }

        [Required]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Your Password")]

        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

    }
}
