using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "You need to provide product's title")]
        [Display(Name ="Category's name")]
        public string Name { get; set; }
        [Display(Name = "Category's description")]
        public string Description { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
