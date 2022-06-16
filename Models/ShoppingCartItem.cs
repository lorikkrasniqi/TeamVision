using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; } 

        public Products Products { get; set; }  

        public int Quantity { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
