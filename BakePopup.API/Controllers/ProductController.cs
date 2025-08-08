using BakePopup.API.ViewModels;
using BakePopup.Application.Queries;
using BakePopup.Application.Services;
using BakePopup.Domain.Products.Entities;
using BakePopup.Domain.Products.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BakePopup.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            try
            {
                var product = await _productService.CreateProduct(request.Name, request.Description, request.Price, request.Quantity);
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
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
        [HttpGet()]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            var productViewModels = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList();
            return Ok(productViewModels);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetProductById(id);
            if (product is null)
            {
                return NotFound();
            }
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            };
            return Ok(productViewModel);
        }
        // test endpoint for mediatR
        [HttpGet("test")]
        public async Task<IActionResult> TestEndpoint()
        {
            return Ok(await _mediator.Send(new TestQuery()));
        }
    }
}