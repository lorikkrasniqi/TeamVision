using VisionStore.Data.Cart;
using VisionStore.Models;

namespace VisionStore.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }

        public Products Products { get; set; }


        public double ShoppingCartTotal { get; set; }
    }
}
