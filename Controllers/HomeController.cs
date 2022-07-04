using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VisionStore.Data;
using VisionStore.Services.IServices;
using VisionStore.Models;
using Microsoft.EntityFrameworkCore;
using VisionStore.Data.ViewModels;
using System.Security.Claims;
using VisionStore.Data.Cart;
using Microsoft.AspNetCore.Authorization;

namespace VisionStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductsService _service;
        private readonly ILogger<HomeController> _logger;
        private readonly ShoppingCart _shoppingCart;
        private readonly ProductDeals _productDeals;

        public HomeController(ILogger<HomeController> logger, IProductsService service, AppDbContext context, ShoppingCart shoppingCart,ProductDeals productDeals)
        {
            _service = service;
            _context = context;
            _logger = logger;
            _shoppingCart = shoppingCart;
            _productDeals = productDeals;
        }
         public async Task<IActionResult> Index()
        {
            
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var item = _productDeals.GetProductsDealsItems();
            _productDeals.ProductDealsItems = item;


            ShoppingCartVM productVm = new()
            {
                Products = await _context.Products.ToListAsync(),
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                ProductDeals = _productDeals,
            };  


           

     


            //var allProducts = await _context.Products.ToListAsync();
            return View(productVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}