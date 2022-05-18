using VisionStore.Models;

namespace VisionStore.Services.IServices
{
    public interface IProductsService
    {
        IEnumerable<Products> GetAll();
        Products GetById(int id);   
        void Add(Products product);
        void Update(Products product);
        void Delete(int id);
    }
}
