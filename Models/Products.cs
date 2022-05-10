using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Titulli i produktit")]
        [Required(ErrorMessage = "Fusha titulli i produktit duhet plotesuar")]
        public string Title { get; set; }

        [Display(Name = "Pershkrimi i produktit")]
        [Required(ErrorMessage = "Pershkrimi i produktit duhet plotesuar")]
        public string Description { get; set; }

        [Display(Name = "Cmimi")]
        [Required(ErrorMessage = "Fusha cmimi duhet plotesuar")]
        public double Price { get; set; }

        [Display(Name = "Sasia")]
        [Required(ErrorMessage = "Fusha sasia duhet plotesuar")]
        public int Quantity { get; set; }

        public ICollection<OrderedProducts> OrderedProducts { get; set; }
    }
}
