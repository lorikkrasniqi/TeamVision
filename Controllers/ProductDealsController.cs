using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisionStore.Data.Cart;
using VisionStore.Data.ViewModels;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Controllers
{
    public class ProductDealsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ProductDeals _productDeals;

        public ProductDealsController(IProductsService productsService,ProductDeals productDeals)
        {
            _productsService = productsService;
            _productDeals = productDeals;
        }

     
        public IActionResult Index()
        {
            var items = _productDeals.GetProductDealsItems();
            _productDeals.ProductDealsItems = items;
            

            ShoppingCartVM productVm = new()
            {
                ProductDeals = _productDeals,
                
            };
            
            

            return View(productVm);
        }
       
        [AutoValidateAntiforgeryToken]
        [Authorize]
        public async Task<IActionResult> AddToProductDeals(int id,ProductDealsItem productDeals)
        {
           
            var item = await _productsService.GetByIdAsync(id);

            if(item != null)
            {
                _productDeals.AddItemToDeal(item);
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> RemoveItemFromDeal(int id)
        {
            var item = await _productsService.GetByIdAsync(id);

            if (item != null)
            {
                _productDeals.RemoveItemFromDeal(item);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
