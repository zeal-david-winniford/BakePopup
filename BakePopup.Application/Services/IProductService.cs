using BakePopup.API.ViewModels;
namespace BakePopup.Application.Services
{
    public interface IProductService
    {
        ProductDto CreateProduct(CreateProductRequest request);
    }

}