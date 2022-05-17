using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionStore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
       
        public ICollection<OrderedProducts> OrderedProducts { get; set; }

    }
}
