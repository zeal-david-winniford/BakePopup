using BakePopup.API.ViewModels;
using BakePopup.Application.Services;
using BakePopup.Domain.Products.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BakePopup.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public IProductService ProductService { get; }
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpPost()]
        public IActionResult CreateProduct([FromBody] CreateProductRequest request)
        {
            try
            {
                var productDto = ProductService.CreateProduct(request);
                return Ok(productDto);
            }
            catch (InvalidPriceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}