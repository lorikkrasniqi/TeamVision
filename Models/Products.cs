using System.ComponentModel.DataAnnotations;

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

        public ICollection<OrderedProducts> OrderedProducts { get; set; }
    }
}
