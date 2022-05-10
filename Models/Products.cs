using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Product Title : ")]
        [Required(ErrorMessage = "This field is required")]
        public string Title { get; set; }

        [Display(Name = "Product Description : ")]
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [Display(Name = "Price : ")]
        [Required(ErrorMessage = "This field is required")]
        public double Price { get; set; }

        [Display(Name = "Quantity : ")]
        [Required(ErrorMessage = "This field is required")]
        public int Quantity { get; set; }

        public ICollection<OrderedProducts> OrderedProducts { get; set; }
    }
}
