using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Models;
using VisionStore.Services.IServices;

namespace VisionStore.Services.IServices
{
    public interface IUnitWork
    {

        ICategoryService CategoryService { get; }

        IProductsService ProductsService { get; }

        IShoppingCart ShoppingCart { get; }

        IApplicationUser ApplicationUser { get; }

        void Save();
    }
}
