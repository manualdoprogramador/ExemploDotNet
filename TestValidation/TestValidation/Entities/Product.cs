using TestValidation.Exceptions;

namespace TestValidation.Entities
{
    public sealed class Product
    {
        public Product(string name, decimal price, int id = 0)
        {
            if (id > 0)
                Id = id;

            if (string.IsNullOrEmpty(name))
                throw new DomainExceptionProductNameIsNull("[Name] - Nome deve ser informado!");

            if (price <= 0)
                throw new DomainExceptionProductPriceLessThenZero("[Price] - Preço deve ser maior que zero");

            Name = name;
            Price = price;
            InclusionDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime InclusionDate { get; set; }
    }
}
