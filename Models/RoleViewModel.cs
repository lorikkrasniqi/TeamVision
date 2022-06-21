using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class RoleViewModel
    {
        [Key]
        public string RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
