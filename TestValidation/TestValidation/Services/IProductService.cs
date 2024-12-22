using TestValidation.DTOs;

namespace TestValidation.Services
{
    public interface IProductService
    {
        ResultService CreateValidationWithException(ProductDTO productDTO);
        ResultService CreateValidationWithoutException(ProductDTO productDTO);
    }
}
