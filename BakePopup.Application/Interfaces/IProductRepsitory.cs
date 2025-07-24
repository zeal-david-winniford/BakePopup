using BakePopup.Domain.Products.Entities;

namespace BakePopup.Application.Interfaces
{
    public interface IProductRepository
    {
        Task Save(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid id);
    }

}