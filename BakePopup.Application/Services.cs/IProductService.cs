using BakePopup.Domain.Products.Entities;

namespace BakePopup.Application.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(string name, string description, decimal price, int quantity);
        Task<Product?> GetProductById(Guid id);
        Task<List<Product>> GetAllProducts();
        // Task UpdateProduct(Product product);
        // Task DeleteProduct(Guid id);
    }

}