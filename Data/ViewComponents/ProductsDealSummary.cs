using Microsoft.AspNetCore.Mvc;
using VisionStore.Data.Cart;

namespace VisionStore.Data.ViewComponents
{
    public class ProductsDealSummary : ViewComponent
    {

        private readonly ProductDeals _productDeal;

        public ProductsDealSummary(ProductDeals productDeals)
        {
            _productDeal = productDeals;
        }

        public IViewComponentResult Invoke()
        {
            var items = _productDeal.GetProductsDealsItems();
            return View(items.Count);
        }

    }
}
