using Microsoft.EntityFrameworkCore;
using VisionStore.Models;

namespace VisionStore.Data.Cart
{
    public class ProductDeals
    {
        public AppDbContext _context { get; set; }

        public string ProductDealsId { get; set; }

        public List<Products> Products { get; set; }

        public List<ProductDealsItem> ProductDealsItems { get; set; }



        public ProductDeals(AppDbContext context)
        {
            _context = context;
        }

        public static ProductDeals GetProduct(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string dealId = session.GetString("DealId") ?? Guid.NewGuid().ToString();

            session.SetString("DealId", dealId);

            return new ProductDeals(context) { ProductDealsId = dealId };
        }

        public void AddItemToDeal(Products products)
        {
            var productDealItem = _context.ProductDealsItem.FirstOrDefault(n => n.Products.ProductId == products.ProductId && n.ProductDealsId == ProductDealsId && n.Products.Price == );

            if (productDealItem == null)
            {
                productDealItem = new ProductDealsItem()
                {
                    ProductDealsId = ProductDealsId,
                    Products = products,
                
                };
                _context.ProductDealsItem.Add(productDealItem);
            }
            else
            {
                productDealItem.Quantity++;
            }
            _context.SaveChanges();

        }


        public void RemoveItemFromDeal(Products products)
        {
            var productDealItem = _context.ProductDealsItem.FirstOrDefault(n => n.Products.ProductId == products.ProductId && n.ProductDealsId == ProductDealsId);

            if (productDealItem != null)
            {
                if (productDealItem.Quantity > 1)
                {
                    productDealItem.Quantity--;
                }
                else
                {
                    _context.ProductDealsItem.Remove(productDealItem);

                }
            }

            _context.SaveChanges();

        }

        public List<ProductDealsItem> GetProductDealsItems()
        {
            return ProductDealsItems ?? (ProductDealsItems = _context.ProductDealsItem.Where(n => n.ProductDealsId == ProductDealsId).Include(n => n.Products).ToList());
        }
        public List<ProductDealsItem> GetProductsDealsItems()
        {
            return ProductDealsItems ?? (ProductDealsItems = _context.ProductDealsItem.Where(n => n.ProductDealsId == ProductDealsId).Include(n => n.Products).ToList());
        }

    }
}
