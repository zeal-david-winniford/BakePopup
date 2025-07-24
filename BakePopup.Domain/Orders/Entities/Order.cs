using BakePopup.Domain.Orders.Exceptions;
using BakePopup.Domain.Products.Entities;
using BakePopup.Domain.Shared;

namespace BakePopup.Domain.Orders.Entities
{
    public class Order : AggregateRoot<Guid>
    {
        internal Order(Guid id, string customerName, DateTime createdDate) : base(id)
        {
            CustomerName = customerName;
            CreatedDate = createdDate;
        }

        public string CustomerName { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public List<ProductOrder> Products { get; private set; } = new List<ProductOrder>();

        public static Order Create(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                throw new InvalidOrderException("Customer name cannot be empty.");
            }

            return new Order(Guid.NewGuid(), customerName, DateTime.UtcNow);
        }

        public void AddProduct(Guid productId, int quantity)
        {
            var product = ProductOrder.Create(productId, quantity);
            Products.Add(product);
        }
    }

}