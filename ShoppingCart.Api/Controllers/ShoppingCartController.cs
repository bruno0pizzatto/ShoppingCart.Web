using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Extensions;
using ShoppingCart.Api.Repositories.Contracts;
using ShoppingCart.Models.DTOs;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository,
                                      IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await this.shoppingCartRepository.GetItems(userId);

                if(cartItems == null) 
                {
                    return NoContent();
                }

                var products = await this.productRepository.GetItems();

                if(products == null)
                {
                    throw new Exception("No products exist in the system");
                }
                var cartItemsDto = cartItems.ConvertToDto(products);

                return Ok(cartItemsDto);

            }
            catch (Exception ex)
            {

               return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
