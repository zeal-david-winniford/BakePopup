using BakePopup.API.ViewModels;
using BakePopup.Domain.Products.Entities;
using BakePopup.Domain.Products.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BakePopup.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpPost()]
        public IActionResult CreateProduct([FromBody] CreateProductRequest request)
        {
            try
            {
                var product = Product.Create(request.Name, request.Description, request.Price, request.Quantity);
                var productViewModel = new ProductViewModel
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity
                };
                return Ok(productViewModel);
            }
            catch (InvalidPriceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}