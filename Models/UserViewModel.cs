using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VisionStore.Areas.Identity.Data;
namespace VisionStore.Models
{
    public class UserViewModel : ApplicationUser
    {
        public string Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



    }
}