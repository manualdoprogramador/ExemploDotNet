using TestValidation.DTOs;
using TestValidation.Entities;
using TestValidation.Services.Errors;

namespace TestValidation.Services
{
    public class ProductService : IProductService
    {
        public ResultService CreateValidationWithException(ProductDTO productDTO)
        {
            var product = new Product(productDTO.Name ?? string.Empty, productDTO.Price ?? 0);
            return ResultService.Ok("Produto Cadastrado");
        }

        public ResultService CreateValidationWithoutException(ProductDTO productDTO)
        {
            if (string.IsNullOrEmpty(productDTO.Name))
                return ResultService.Fail(ValidationError.Product.NameNull);
            if ((productDTO.Price ?? 0) <= 0)
                return ResultService.Fail(ValidationError.Product.PriceZero);

            var product = new Product(productDTO.Name ?? string.Empty, productDTO.Price ?? 0);
            return ResultService.Ok("Produto Cadastrado");
        }
    }
}
