namespace TestValidation.Services.Errors
{
    public static class ValidationError
    {
        public static class Product
        {
            public static readonly string NameNull = "[Name] - Deve ser informado";
            public static readonly string PriceZero = "[Price] - Deve ser maior que zero";
        }
    }
}
