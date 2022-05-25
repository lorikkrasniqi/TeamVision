using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionStore.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<OrderedProducts> OrderedProducts { get; set; }
     
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }  


        [Required(ErrorMessage ="Insert product image")]
        [Display(Name ="Product Image")]
        [NotMapped]
        public IFormFile productImage { get; set; }


    }
}
