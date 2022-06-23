using Microsoft.AspNetCore.Mvc;
using VisionStore.Data.Cart;
using VisionStore.Data.ViewModels;
using VisionStore.Services.IServices;

namespace VisionStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductsService productsService,ShoppingCart shoppingCart)
        {
            _productsService = productsService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;


            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _productsService.GetByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productsService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(Index));
        }

        #region ClientId_ClientSecret
        private string _paypalEnvironment = "sandbox";
        private string _clientId = "ATl6zaxuHp8rCIa - der0seGwLWooOHXk_ZnoL7e46 - 4esc5Y6cO1waxr2ZIydPkJm4CwTlpMLIULekzD";
        private string _secret = "EBJv8U4V0rGC6yIHIVBmy6WcZLTZ4B5MjOadDI7PNeYpurHWLDB1GnRgrr4mRbCH0ceyiGN1zA411zTC";
        #endregion
    }
}
