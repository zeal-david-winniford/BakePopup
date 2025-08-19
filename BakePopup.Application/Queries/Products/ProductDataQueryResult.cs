namespace BakePopup.Application.Queries.Products
{
    public class ProductDataQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public uint Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}