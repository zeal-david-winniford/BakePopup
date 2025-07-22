using BakePopup.Domain.Products.Exceptions;
using BakePopup.Domain.Shared;

namespace BakePopup.Domain.Products.Entities
{
    public class Product : AggregateRoot<Guid>
    {
        internal Product(Guid id, string name, string description, decimal price, int quantity) : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int Quantity { get; private set; } = 0;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public static Product Create(string name, string description, decimal price, int quantity = 0)
        {
            if (price < 0)
            {
                throw new InvalidPriceException(price);
            }
            // what would the right way to validate that name is unique?
            // either handle in the application layer or use a domain service
            // in domain layer create a service that checks for uniqueness
            return new Product(Guid.NewGuid(), name, description, price, quantity);
        }

    }
}
