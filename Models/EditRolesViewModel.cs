using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class EditRolesViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage="Role name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }

    }
}
