namespace VisionStore.Models
{
    public class OrderedProducts
    {
        public int OrderID { get; set; }
        public Order Orders { get; set; }
        public int ProductID { get; set; }
        public Products Products { get; set; }
    }
}
