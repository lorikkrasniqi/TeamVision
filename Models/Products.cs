using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VisionStore.Data.Cart;
using VisionStore.Data.ViewModels;

namespace VisionStore.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="You need to provide product's title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You need to provide product's Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You need to provide product's Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "You need to provide product's Quantity")]
        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Insert product image")]
        [Display(Name = "Product Image")]
        [NotMapped]
        public IFormFile productImage { get; set; }


        [Required(ErrorMessage = "Insert product images")]
        [Display(Name = "Product Images")]
        [NotMapped]
        public IFormFile[] Images { get; set; }

        public ICollection<OrderedProducts> OrderedProducts { get; set; }


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        [NotMapped]
        public List<ProductImages> ProductImages { get; set; }

        internal static object AsNoTacking()
        {
            throw new NotImplementedException();
        }
    }
}
