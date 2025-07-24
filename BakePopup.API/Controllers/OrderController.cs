namespace BakePopup.API.Controllers
{
    using BakePopup.API.ViewModels;
    using BakePopup.Domain.Orders.Entities;
    using BakePopup.Domain.Orders.Exceptions;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public ActionResult<OrderCreatedViewModel> CreateOrder(CreateOrderRequest request)
        {
            try
            {
                // application does not have access to view models
                // some companies have sdk project - shared contracts
                var order = Order.Create(request.CustomerName);
                foreach (var product in request.Products)
                {
                    order.AddProduct(product.ProductId, product.Quantity);
                }

                var viewModel = new OrderCreatedViewModel
                {
                    CustomerName = order.CustomerName,
                    CreatedDate = order.CreatedDate,
                    Products = order.Products.Select(p => new ProductOrderViewModel
                    {
                        ProductName = "Product Name Placeholder", // Replace with actual product name retrieval logic
                        Quantity = p.Quantity
                    }).ToList()
                };

                return CreatedAtAction(nameof(CreateOrder), viewModel);
            }
            catch (InvalidOrderException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}