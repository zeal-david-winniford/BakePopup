namespace BakePopup.API.Controllers
{
    using BakePopup.API.ViewModels;
    using BakePopup.Domain.Products.Entities;
    using BakePopup.Domain.Products.Exceptions;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductRequest request)
        {
            try
            {
                var product = Product.Create(request.Name, request.Description, request.Price, request.Quantity);
                return Ok(product);
            }
            catch (InvalidPriceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    
}