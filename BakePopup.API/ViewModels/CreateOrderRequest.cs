namespace BakePopup.API.ViewModels
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public List<CreateProductOrderRequest> Products { get; set; } = new List<CreateProductOrderRequest>();
    }

    public class CreateProductOrderRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}