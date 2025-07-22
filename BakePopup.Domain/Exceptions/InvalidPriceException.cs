namespace BakePopup.Domain.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(decimal price)
            : base($"The price '{price}' is invalid.")
        {
        }
    }
}
