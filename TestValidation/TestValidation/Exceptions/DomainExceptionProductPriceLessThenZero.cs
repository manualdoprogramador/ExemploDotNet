namespace TestValidation.Exceptions
{
    public class DomainExceptionProductPriceLessThenZero : Exception
    {
        public DomainExceptionProductPriceLessThenZero(string? message) : base(message)
        {
        }
    }
}
