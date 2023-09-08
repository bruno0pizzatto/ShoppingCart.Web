using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Extensions;
using ShoppingCart.Api.Repositories.Contracts;
using ShoppingCart.Models.Dtos;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItems();
                var productCategories = await this.productRepository.GetCategories();

                if(products == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDto = products.ConvertToDto(productCategories);
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }
    }
}
