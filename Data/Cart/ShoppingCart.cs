using Microsoft.EntityFrameworkCore;
using VisionStore.Models;

namespace VisionStore.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<Products> Products { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }



        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Products products, string applicationUserId)
        {
            var shoppingCartItem = _context.ShoppingCartItem.FirstOrDefault(n => n.Products.ProductId == products.ProductId && n.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Products = products,
                    Quantity = 1,
                    ApplicationUserId = applicationUserId

                };
                _context.ShoppingCartItem.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();

        }


        public void RemoveItemFromCart(Products products)
        {
            var shoppingCartItem = _context.ShoppingCartItem.FirstOrDefault(n => n.Products.ProductId == products.ProductId && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                 if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                }
                else
                {
                    _context.ShoppingCartItem.Remove(shoppingCartItem);

                }
            }
          
            _context.SaveChanges();

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItem.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Products).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItem.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Products.Price * n.Quantity).Sum();
           
        }
    }

