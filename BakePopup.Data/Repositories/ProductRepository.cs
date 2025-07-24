using BakePopup.Application.Interfaces;
using BakePopup.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakePopup.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BakePopupContext context;

        public ProductRepository(BakePopupContext context)
        {
            this.context = context;
        }


        public async Task<List<Product>> GetAllProducts()
        {
            var products = await context.Products.ToListAsync();
            return products.Select(p => new Product(p.DomainId,
                p.Name,
                p.Description,
                p.Price,
                (int)p.Quantity,
                p.CreatedAt
            )).ToList();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.DomainId == id);
            if (product == null)
            {
                return null;
            }
            return new Product(product.DomainId,
                product.Name,
                product.Description,
                product.Price,
                (int)product.Quantity,
                product.CreatedAt);
        }

        public Task Save(Product product)
        {
            var productToAdd = new Data.Entities.Product
            {
                DomainId = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = (uint)product.Quantity,
                CreatedAt = product.CreatedAt
            };
            context.Products.Add(productToAdd);
            return context.SaveChangesAsync();
        }
    }

}