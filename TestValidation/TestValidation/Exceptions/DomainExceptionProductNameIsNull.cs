namespace TestValidation.Exceptions
{
    public class DomainExceptionProductNameIsNull : Exception
    {
        public DomainExceptionProductNameIsNull(string? message) : base(message)
        {
        }
    }
}
