using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisionStore.Data.Cart;
using VisionStore.Data.ViewModels;
using VisionStore.Models;
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

        [Authorize]
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;


            var items = _shoppingCart.GetUserShoppingCartItems(userId);
            _shoppingCart.ShoppingCartItems = items;
          

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetUserShoppingCartTotal(userId)
            };
            return View(response);
        }
       
        [AutoValidateAntiforgeryToken]
        [Authorize]
        public async Task<IActionResult> AddToShoppingCart(int id,ShoppingCartItem shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;

               

            var item = await _productsService.GetByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item,claim.Value);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
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
