using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionStore.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<Order> orders { get; set; }
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Roles Roles { get; set; }
    }
}
