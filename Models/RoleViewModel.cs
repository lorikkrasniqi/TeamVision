using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class RoleViewModel
    {
        [Key]
        int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
