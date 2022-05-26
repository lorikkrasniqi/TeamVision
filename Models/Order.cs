using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionStore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "You need to provide your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "You need to provide city's name")]
        public string City { get; set; }
        public ICollection<OrderedProducts> OrderedProducts { get; set; }

    }
}
