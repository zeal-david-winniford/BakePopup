using BakePopup.API.ViewModels;
using BakePopup.Domain.Products.Entities;

namespace BakePopup.Application.Services
{
    public class ProductService : IProductService
    {
        public ProductDto CreateProduct(CreateProductRequest request)
        {
            var product = Product.Create(request.Name, request.Description, request.Price, request.Quantity);
            return new ProductDto
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity
                };
        }
    }
}