namespace BakePopup.API.ViewModels
{
    public class CreateProductRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}