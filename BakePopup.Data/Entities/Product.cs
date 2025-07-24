using System.ComponentModel.DataAnnotations;

namespace BakePopup.Data.Entities
{
    public class Product
    {
        [Key]
        public uint Id { get; set; }
        public Guid DomainId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public uint Quantity { get; set; }
        public DateTime CreatedAt { get; private set; }
    }
}