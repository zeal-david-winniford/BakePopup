using BakePopup.Domain.Orders.Exceptions;
using BakePopup.Domain.Shared;

namespace BakePopup.Domain.Products.Entities
{
    public class ProductOrder : AggregateRoot<Guid>
    {
        public ProductOrder(Guid id, Guid productId, int quantity) : base(id)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public static ProductOrder Create(Guid productId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOrderException("Product quantity must be greater than zero.");
            }

            return new ProductOrder(Guid.NewGuid(), productId, quantity);
        }
    }
}