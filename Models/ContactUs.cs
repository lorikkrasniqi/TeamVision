using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactUsId { get; set; }
        [Required(ErrorMessage ="You must provide your full name")]
        [Display(Name="Your Full name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "You must provide your Email")]
        [Display(Name = "Your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must provide your full name")]
        [Display(Name = "Your Message")]
        public string Message { get; set; }

    }
}
