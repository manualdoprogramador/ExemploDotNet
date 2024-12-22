using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestValidation.DTOs;
using TestValidation.Exceptions;
using TestValidation.Services;

namespace TestValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("create-exception")]
        public IActionResult CreateValidationWithException(ProductDTO productDTO)
        {
            try
            {
                var result = _productService.CreateValidationWithException(productDTO);
                return Ok(result);
            }
            catch (DomainExceptionProductNameIsNull ex)
            {                
                return BadRequest(ResultService.Fail(ex.Message));
            }
            catch (DomainExceptionProductPriceLessThenZero ex)
            {
                return BadRequest(ResultService.Fail(ex.Message));
            }
        }

        [HttpPost]
        [Route("create-without-exception")]
        public IActionResult CreateValidationWithoutException(ProductDTO productDTO)
        {
            var result = _productService.CreateValidationWithoutException(productDTO);
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
