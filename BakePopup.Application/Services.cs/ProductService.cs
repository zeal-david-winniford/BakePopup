namespace BakePopup.Application.Services
{
    using BakePopup.Application.Interfaces;
    using BakePopup.Domain.Products.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(string name, string description, decimal price, int quantity)
        {
            var product = Product.Create(name, description, price, quantity);
            await _productRepository.Save(product);
            return product;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }
        public async Task<Product?> GetProductById(Guid id)
        {
            return await _productRepository.GetProductById(id);
        }
    }

}