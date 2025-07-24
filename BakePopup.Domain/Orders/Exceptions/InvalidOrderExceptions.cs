namespace BakePopup.Domain.Orders.Exceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException(string message)
            : base(message)
        {
        }
    }
}
