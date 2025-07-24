namespace BakePopup.API.ViewModels
{
    public class OrderCreatedViewModel
    {
        public string CustomerName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public List<ProductOrderViewModel> Products { get; set; } = new List<ProductOrderViewModel>();
    }

    public class ProductOrderViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

}