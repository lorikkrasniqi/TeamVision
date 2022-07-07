using VisionStore.Data.Cart;
using VisionStore.Models;

namespace VisionStore.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }

        public ProductDeals ProductDeals { get; set; }

        public IEnumerable<Products> Products { get; set; }

        public IEnumerable<Products> Product { get; set; }



        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public double ShoppingCartTotal { get; set; }
    }
}
