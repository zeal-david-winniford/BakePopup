namespace BakePopup.Domain.Products.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(decimal price)
            : base($"The price '{price}' is invalid.")
        {
        }
    }
}
